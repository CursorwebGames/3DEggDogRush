using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    public bool isTouched = false;
    public GameObject enemyObject;

    private LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // prevent the function being called more than once
        if (isTouched) return;

        if (other.CompareTag("Player"))
        {
            isTouched = true;
            levelManager.AddScore(10);
            Destroy(enemyObject);
            // todo: add smash animation
        }   
    }
}
