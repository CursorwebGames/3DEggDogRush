using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{
    public Text score;
    private LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        UpdateScore();
    }


    public void UpdateScore()
    {
        score.text = $"{levelManager.score:n0}";
    }
}
