using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovemnt : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerRB;

    [SerializeField]
    private float moveSpeed;

    private void Update() {
        
        if(Input.GetKey(KeyCode.W))
        {
            playerRB.position += -transform.forward *moveSpeed *Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            playerRB.position += transform.forward *moveSpeed *Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A))
        {
            playerRB.position += transform.right *moveSpeed *Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            playerRB.position += -transform.right *moveSpeed *Time.deltaTime;
        }

    }
}
