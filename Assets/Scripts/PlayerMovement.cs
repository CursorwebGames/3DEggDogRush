using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public EggDogAnimations eggDogAnimations;

    public bool grounded = true;
    public bool dodging = false;
    public Collider upper;

    public float moveSpeed;
    public float maxHeight;
    public float laneWidth;

    // if you are pushed back this much the game is over
    public float gameOverZ;

    public Rigidbody rb;
    public float jumpHeight;

    private void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        rb.MovePosition(transform.position + new Vector3(horiz, 0, 0) * moveSpeed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -laneWidth, laneWidth), transform.position.y, transform.position.z);

        if (vert < 0)
        {
            if (!grounded && transform.position.y > 0.5f) rb.AddForce(0, -jumpHeight / 2, 0);
            if (!dodging)
            {
                eggDogAnimations.Dodge();
                upper.enabled = false;
                dodging = true;
            }
        } else if (dodging)
        {
            eggDogAnimations.Stand();
            upper.enabled = true;
            dodging = false;
        }

        if (grounded && Input.GetAxis("Vertical") > 0 || Input.GetKeyDown(KeyCode.Space))
        {
            grounded = false;
            rb.AddForce(0, jumpHeight, 0);
            eggDogAnimations.Jump();
        }

        if (transform.position.z < gameOverZ)
        {
            Debug.Log("GAME OVER");
            throw new System.NotImplementedException();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Unjumpable"))
        {
            grounded = true;
            eggDogAnimations.Ground();
        }

        if (collision.collider.CompareTag("Beams"))
        {
            Debug.Log("GAME OVER");
            throw new System.NotImplementedException();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!collision.collider.CompareTag("Unjumpable")) grounded = false;
    }
}
