using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnMovement(float horizontal, float vertical)
    {
        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

        animator.SetFloat("horizontal", horizontal * offset);
        animator.SetFloat("vertical", vertical * offset);
    }

    public void OnJump()
    {
        animator.SetTrigger("onJump");
    }

    public void OnAttack()
    {
        animator.SetTrigger("onAttack");
    }
}
