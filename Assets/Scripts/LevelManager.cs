using System;
using System.Collections.Generic;
using UnityEngine;


// This will be used to abstract level chunks and make chunks.
// Each *chunk* will have their respective tag based on biometype.
// Each *biome chunk* -- the list of all possible chunks that can spawn will be based on the *chunk* and its tag.
public class LevelManager : MonoBehaviour
{
    public int score = 0;
    public Dictionary<BiomeType, GameObject[]> levelChunks = new Dictionary<BiomeType, GameObject[]>();

    private void Start()
    {
        foreach (string biome in Enum.GetNames(typeof(BiomeType)))
        {
            BiomeType biomeEnum = (BiomeType)Enum.Parse(typeof(BiomeType), biome);
            levelChunks.Add(biomeEnum, GameObject.FindGameObjectsWithTag($"{biome}Chunk"));
        }
    }
}
