using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float  lookSensitivity;

    private Vector2 rotation;

    [SerializeField]
    private float maxAngle;

    private void Start() 
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() 
    {
        //Vector2 targetVelocity = GetMousePos() * lookSensitivity;

        //rotation += targetVelocity * Time.deltaTime;

        //rotation.y = ClampAngle(rotation.y);
        //transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);

        Vector2 aimInput = InputHandler.Instance.Aim();

        rotation += aimInput * lookSensitivity * Time.deltaTime;

        rotation.y = ClampAngle(rotation.y);

        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
    }

    private Vector2 GetMousePos()
    {
        Vector2 mousePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        return mousePos;
    }

    private float ClampAngle(float angle)
    {
        return Mathf.Clamp(angle, -maxAngle, maxAngle);
    }
}
