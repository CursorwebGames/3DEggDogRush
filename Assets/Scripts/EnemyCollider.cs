using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    public bool isTouched = false;
    private LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // prevent the function being called more than once
        if (isTouched) return;
        isTouched = true;

        if (other.CompareTag("Player"))
        {
            levelManager.AddScore(10);
            Destroy(gameObject);
            // todo: add smash animation
        }   
    }
}
