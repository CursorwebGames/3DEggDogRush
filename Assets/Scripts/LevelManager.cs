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
    public Dictionary<BiomeType, GameObject[]> sceneChunks = new Dictionary<BiomeType, GameObject[]>();

    public Dictionary<BiomeType, Material> levelMats = new Dictionary<BiomeType, Material>();
    public Dictionary<BiomeType, GameObject> sceneMats = new Dictionary<BiomeType, GameObject>();

    public Vector3 offset;
    public Vector3 leftOffset;
    public Vector3 rightOffset;
    public Vector3 boneOffset;

    public Vector3 startPos;
    public Vector3 midPos;
    public Vector3 endPos;

    public float tick = 0;
    public float sceneTick = 0;
    public float maxTick;

    public MeshRenderer meshRenderer;

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
            sceneChunks.Add(biomeEnum, Resources.LoadAll<GameObject>($"scenes/{biome}"));
            levelMats.Add(biomeEnum, Resources.Load<Material>($"materials/{biome}/background"));
            sceneMats.Add(biomeEnum, Resources.Load<GameObject>($"materials/{biome}/road"));
        }

        textUpdater = FindObjectOfType<TextUpdater>();
        gameManager = FindObjectOfType<GameManager>();
        biome = gameManager.biome;

        meshRenderer.material = levelMats[biome];

        GameObject plane = sceneMats[biome];
        Instantiate(plane, startPos, Quaternion.identity);
        Instantiate(plane, midPos, Quaternion.identity);
        Instantiate(plane, endPos, Quaternion.identity);
    }

    private void Update()
    {
        GameObject[] chunkArr = levelChunks[biome];
        GameObject[] sceneArr = sceneChunks[biome];

        tick += Time.deltaTime;
        sceneTick += Time.deltaTime;
        if (tick > maxTick)
        {
            tick = 0;
            int index = UnityEngine.Random.Range(0, chunkArr.Length);

            GameObject prefab = chunkArr[index];

            Instantiate(prefab, offset, Quaternion.identity);
            Instantiate(boneBreak, offset + boneOffset, Quaternion.identity);
        }

        if (sceneTick > maxTick / 2)
        {
            sceneTick = 0;
            int index = UnityEngine.Random.Range(0, sceneArr.Length);
            int index2 = UnityEngine.Random.Range(0, sceneArr.Length);

            GameObject left = sceneArr[index];
            GameObject right = sceneArr[index2];

            Instantiate(left, leftOffset, Quaternion.identity);
            Instantiate(right, rightOffset, Quaternion.identity);
        }
    }

    public void AddScore(int num = 1)
    {
        score += num;
        textUpdater.UpdateScore();
    }
}
