using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;
    [SerializeField]
    private Transform cameraTransform;
    private Movement3D movement3D;
    private PlayerAnimator playerAnimator;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        movement3D = GetComponent<Movement3D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        playerAnimator.OnMovement(x, z);
        movement3D.MoveSpeed = z > 0 ? 2.5f : 2.0f;
        movement3D.MoveTo(cameraTransform.rotation * new Vector3(x, 0, z));

        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            movement3D.MoveSpeed = 5.0f;
        }

        if(Input.GetKeyDown(jumpKeyCode))
        {
            playerAnimator.OnJump();
            movement3D.JumpTo();
        }

        if(Input.GetMouseButtonDown(1))
        {
            playerAnimator.OnAttack();
        }
    }
}
