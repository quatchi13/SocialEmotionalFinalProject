using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    [SerializeField] protected List<Image> icons = new List<Image>();

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

        for (int i = 0; i < icons.Count; i++)
        {
            icons[i].gameObject.SetActive(false);
        }

        GetComponent<Interactable>().CompleteInteraction();
    }

    public void FailTask()
    {
        print("TASK FAILED");

        taskComplete = false;
        taskBegun = false;

        for (int i = 0; i < icons.Count; i++)
        {
            icons[i].gameObject.SetActive(false);
        }
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

