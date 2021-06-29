using UnityEngine;

public class EggDogAnimations : MonoBehaviour
{
    public Animator animator;

    public void Jump()
    {
        animator.SetBool("IsJumping", true);
    }

    public void Ground()
    {
        animator.SetBool("IsJumping", false);
    }

    public void Dodge()
    {
        animator.SetBool("IsDodging", true);
    }

    public void Stand()
    {
        animator.SetBool("IsDodging", false);
    }
}
