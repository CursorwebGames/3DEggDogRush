using System;
using System.Collections.Generic;
using UnityEngine;


// This will be used to abstract level chunks and make chunks.
// Each *chunk* will have their respective tag based on biometype.
// Each *biome chunk* -- the list of all possible chunks that can spawn will be based on the *chunk* and its tag.
// Each *chunk* will also add a 'break' in between to facilitate the changing widths.
// This is called a bone break.
public class LevelManager : MonoBehaviour
{
    public int score = 0;
    public GameObject boneBreak;
    public Dictionary<BiomeType, GameObject[]> levelChunks = new Dictionary<BiomeType, GameObject[]>();

    public Vector3 offset;
    public Vector3 boneOffset;

    public float tick = 0;
    public float maxTick;

    private GameManager gameManager;
    private TextUpdater textUpdater;
    private BiomeType biome;

    private void Start()
    {
        tick = maxTick;

        foreach (string biome in Enum.GetNames(typeof(BiomeType)))
        {
            BiomeType biomeEnum = (BiomeType)Enum.Parse(typeof(BiomeType), biome);
            levelChunks.Add(biomeEnum, Resources.LoadAll<GameObject>($"obstacles/{biome}"));
        }

        textUpdater = FindObjectOfType<TextUpdater>();
        gameManager = FindObjectOfType<GameManager>();
        biome = gameManager.biome;
    }

    private void Update()
    {
        GameObject[] chunkArr = levelChunks[biome];

        tick += Time.deltaTime;
        if (tick > maxTick)
        {
            tick = 0;
            int index = UnityEngine.Random.Range(0, chunkArr.Length);
            GameObject prefab = chunkArr[index];
            Instantiate(prefab, offset, Quaternion.identity);
            Instantiate(boneBreak, offset + boneOffset, Quaternion.identity);
        }
    }

    public void AddScore(int num = 1)
    {
        score += num;
        textUpdater.UpdateScore();
    }
}
