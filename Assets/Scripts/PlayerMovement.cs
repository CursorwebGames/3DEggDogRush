using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float laneWidth;
    public float jumpHeight;
    private int offset = 0;

    private void Update()
    {
        bool left = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        bool right = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

        if (left && offset != -1)
        {
            offset--;
            transform.position -= new Vector3(laneWidth, 0, 0);
        }
        else if (right && offset != 1)
        {
            offset++;
            transform.position += new Vector3(laneWidth, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += new Vector3(0, jumpHeight, 0);
        }
    }
}
