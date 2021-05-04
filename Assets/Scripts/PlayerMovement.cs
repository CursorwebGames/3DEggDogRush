using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool grounded = true;

    public float laneWidth;
    private int offset = 0;

    public Rigidbody rb;
    public float jumpHeight;

    private void Update()
    {
        bool left = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        bool right = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

        // todo: animate?
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

        if (grounded && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            grounded = false;
            rb.AddForce(0, jumpHeight, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground")) grounded = true;
    }
}
