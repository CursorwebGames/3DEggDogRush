using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool grounded = true;

    public float moveSpeed;
    public float maxHeight;
    public float laneWidth;

    public Rigidbody rb;
    public float jumpHeight;

    private void Update()
    {
        float horiz = Input.GetAxis("Horizontal");

        rb.MovePosition(transform.position + new Vector3(horiz, 0, 0) * moveSpeed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -laneWidth, laneWidth), Mathf.Clamp(transform.position.y, 2.135f, maxHeight), transform.position.z);

        if (grounded && Input.GetAxis("Vertical") > 0)
        {
            grounded = false;
            rb.AddForce(0, jumpHeight, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("start");
    }
    //(Collision collision)
    //{
    //    if (collision.collider.CompareTag("Ground")) grounded = true;
    //}
}
