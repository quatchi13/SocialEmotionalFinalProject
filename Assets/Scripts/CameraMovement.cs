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
        if (!GetComponent<InteractionSystem>().IsAnyTaskActive())
        {
            Vector2 aimInput = InputHandler.Instance.Aim();

            rotation += aimInput * lookSensitivity * Time.deltaTime;

            rotation.y = ClampAngle(rotation.y);

            transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
        }
    }

    private float ClampAngle(float angle)
    {
        return Mathf.Clamp(angle, -maxAngle, maxAngle);
    }
}
