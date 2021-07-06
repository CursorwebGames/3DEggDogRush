using UnityEngine;

public class CameraAngle : MonoBehaviour
{
    public float tick;

    //public float speedX;
    public float speedY;

    private void Update()
    {
        tick += Time.deltaTime;
        if (tick >= 5) tick = 0;

        RotateY();
    }

    private void RotateY()
    {
        float rotY = speedY;//0.2f * Mathf.Sin(tick / 10);
        Quaternion rotation = Quaternion.AngleAxis(rotY, Vector3.up);
        transform.localRotation *= rotation;
    }
}
