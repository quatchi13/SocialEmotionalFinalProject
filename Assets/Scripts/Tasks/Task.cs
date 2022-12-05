using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    protected bool taskBegun;
    protected bool taskComplete;

    public virtual void BeginTask()
    {
        taskBegun = true;
    }

    public void CompleteTask()
    {
        print("TASK COMPLETE");

        taskComplete = true;
        taskBegun = false;

        GetComponent<Interactable>().CompleteInteraction();
    }

    public void FailTask()
    {
        print("TASK FAILED");

        taskComplete = false;
        taskBegun = false;
    }

    public void ResetTask()
    {
        taskBegun = false;
        taskComplete = false;
    }

    public bool GetTaskComplete()
    {
        return taskComplete;
    }

    public bool IsTaskActive()
    {
        if (taskBegun && !taskComplete)
        {
            return true;
        }

        return false;
    }
}

public enum Buttons //XBOX Controller for Reference
{
    A,
    B,
    X,
    Y,
    LB,
    RB,
    LT,
    RT
}

