using UnityEngine;

public class BoneCollider : MonoBehaviour
{
    public GameObject boneObj;

    private bool isTouched = false;
    private LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isTouched) return;

        if (other.CompareTag("Player"))
        {
            isTouched = true;

            levelManager.AddScore();
            Destroy(boneObj);
        }
    }
}
