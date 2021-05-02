using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum BiomeType
    {
        Park,
        Street
    }

    public int score = 0;
    public BiomeType biome = BiomeType.Park;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
