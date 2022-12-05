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

        Vector2 moveInput = InputHandler.Instance.Move();

        float targetAngle = Mathf.Atan2(moveInput.x, moveInput.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        Vector3 moveDir = /*Quaternion.AngleAxis(45, Vector3.up) * */Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        //playerRB.position += new Vector3(-moveInput.x, 0, -moveInput.y) * moveSpeed * Time.deltaTime;

        if (moveInput.magnitude >= 0.1f)
        {
            playerRB.velocity = moveSpeed * moveDir;
        }

        //if(Input.GetKey(KeyCode.W))
        //{
        //    playerRB.position += -transform.forward *moveSpeed *Time.deltaTime;
        //}
        //else if(Input.GetKey(KeyCode.S))
        //{
        //    playerRB.position += transform.forward *moveSpeed *Time.deltaTime;
        //}

        //if(Input.GetKey(KeyCode.A))
        //{
        //    playerRB.position += transform.right *moveSpeed *Time.deltaTime;
        //}
        //else if(Input.GetKey(KeyCode.D))
        //{
        //    playerRB.position += -transform.right *moveSpeed *Time.deltaTime;
        //}
    }
}
