using UnityEngine;

public class EnemyManager : MonoBehaviour
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
            Debug.Log("tr " + other.tag);
            levelManager.score += 10;
            textUpdater.UpdateScore();
            // todo: add smash animation
            Destroy(gameObject);
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("col " + collision.collider.tag);
            levelManager.score += 10;
            textUpdater.UpdateScore();
            // todo: add smash animation
            Destroy(gameObject);
        }
    }
}
