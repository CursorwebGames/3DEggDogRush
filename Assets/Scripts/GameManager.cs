using UnityEngine;

public enum BiomeType
{
    Park,
    Street
}

// This will be used to change chunks, and anything that should be global.
public class GameManager : MonoBehaviour
{

    public BiomeType biome = BiomeType.Park;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
