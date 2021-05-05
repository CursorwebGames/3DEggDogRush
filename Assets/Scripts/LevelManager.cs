using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


// This will be used to abstract level chunks and make chunks.
// Each *chunk* will have their respective tag based on biometype.
// Each *biome chunk* -- the list of all possible chunks that can spawn will be based on the *chunk* and its tag.
public class LevelManager : MonoBehaviour
{
    public int score = 0;
    public Dictionary<BiomeType, GameObject[]> levelChunks = new Dictionary<BiomeType, GameObject[]>();

    public Vector3 offset;

    public float tick = 0;
    public float maxTick;

    private GameManager gameManager;
    private BiomeType biome;

    private void Start()
    {
        foreach (string biome in Enum.GetNames(typeof(BiomeType)))
        {
            BiomeType biomeEnum = (BiomeType)Enum.Parse(typeof(BiomeType), biome);
            levelChunks.Add(biomeEnum, Resources.LoadAll<GameObject>(biome));
        }

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
            int index = UnityEngine.Random.Range(0, chunkArr.Length - 1);
            GameObject prefab = chunkArr[index];
            Instantiate(prefab, offset, Quaternion.identity);
        }
    }
}
