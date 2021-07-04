using UnityEngine;

public class RoadChunk : MonoBehaviour
{
    public float speed;
    public Vector3 respawnPos;
    public Vector3 killPos;

    private void Update()
    {
        transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        if (transform.position.z < killPos.z) transform.position = respawnPos;
    }
}
