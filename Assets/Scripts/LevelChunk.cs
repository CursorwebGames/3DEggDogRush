using UnityEngine;

public class LevelChunk : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
    }
}
