using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    PlayerInput playerInput;

    InputAction moveAction;
    InputAction aimAction;
    InputAction mouseAimAction;
    InputAction interactAction;
    InputAction button1Action;
    InputAction button2Action;
    InputAction button3Action;
    InputAction leftBumperAction;
    InputAction rightBumperAction;
    InputAction leftTriggerAction;
    InputAction rightTriggerAction;

    public static InputHandler Instance { get; set; }

    private void Awake()
    {
        Instance = this;

        //controls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();

        interactAction = playerInput.actions["Interact"];
        moveAction = playerInput.actions["Move"];
        aimAction = playerInput.actions["Aim"];
        mouseAimAction = playerInput.actions["MouseAim"];
        button1Action = playerInput.actions["TaskButton1"];
        button2Action = playerInput.actions["TaskButton2"];
        button3Action = playerInput.actions["TaskButton3"];
        leftBumperAction = playerInput.actions["LeftBumper"];
        rightBumperAction = playerInput.actions["RightBumper"];
        leftTriggerAction = playerInput.actions["LeftTrigger"];
        rightTriggerAction = playerInput.actions["RightTrigger"];
    }

    public Vector2 Move()
    {
        return moveAction.ReadValue<Vector2>();
    }

    public Vector2 Aim()
    {
        return aimAction.ReadValue<Vector2>();
    }

    public bool Interact()
    {
        return interactAction.triggered;
    }

    public bool TaskButton1()
    {
        return button1Action.triggered;
    }

    public bool TaskButton2()
    {
        return button2Action.triggered;
    }

    public bool TaskButton3()
    {
        return button3Action.triggered;
    }

    public bool LeftBumper()
    {
        return leftBumperAction.triggered;
    }

    public bool RightBumper()
    {
        return rightBumperAction.triggered;
    }

    public bool LeftTrigger()
    {
        return leftTriggerAction.triggered;
    }

    public bool LeftTriggerHeld()
    {
        return leftTriggerAction.IsPressed();
    }

    public bool RightTrigger()
    {
        return rightTriggerAction.triggered;
    }

    public bool RightTriggerHeld()
    {
        return rightTriggerAction.IsPressed();
    }

    public bool AnyButton()
    {
        return interactAction.triggered || button1Action.triggered 
            || button2Action.triggered || button3Action.triggered 
            || leftBumperAction.triggered || rightBumperAction.triggered 
            || leftTriggerAction.triggered || rightTriggerAction.triggered;
    }
}
