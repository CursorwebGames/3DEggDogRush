using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator.SetInteger("AnimNum", Random.Range(0, 2));
    }

    public void Hit()
    {
        animator.SetInteger("AnimNum", -1);
    }
}
