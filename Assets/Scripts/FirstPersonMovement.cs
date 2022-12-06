using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerRB;

    [SerializeField]
    private float moveSpeed;

    private void Update() 
    {
        playerRB.velocity = Vector3.zero;

        if (!GetComponent<InteractionSystem>().IsAnyTaskActive())
        {
            Vector2 moveInput = InputHandler.Instance.Move();

            float targetAngle = Mathf.Atan2(moveInput.x, moveInput.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            if (moveInput.magnitude >= 0.1f)
            {
                playerRB.velocity = moveSpeed * moveDir;
            }
        }
    }
}
