using UnityEngine;

public class BoneManager : MonoBehaviour
{
    private LevelManager levelManager;
    private TextUpdater textUpdater;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        textUpdater = FindObjectOfType<TextUpdater>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelManager.score++;
            textUpdater.UpdateScore();
            Destroy(gameObject);
        }
    }
}
