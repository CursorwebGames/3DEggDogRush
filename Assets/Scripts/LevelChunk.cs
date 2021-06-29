using UnityEngine;

public class LevelChunk : MonoBehaviour
{
    public float speed;

    // the spot when the obstacle should be removed
    public float killZ;

    private void Update()
    {
        transform.position -= new Vector3(0, 0, speed * Time.deltaTime);

        if (transform.position.z < killZ)
        {
            Destroy(gameObject);
        }
    }
}
