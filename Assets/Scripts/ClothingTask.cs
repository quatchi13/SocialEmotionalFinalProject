using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingTask : Task
{
    public override void BeginTask()
    {
        base.BeginTask();

        print("Press both triggers at the same time");
    }

    private void Update()
    {
        if (taskBegun)
        {
            if (InputHandler.Instance.LeftTriggerHeld() && InputHandler.Instance.RightTriggerHeld())
            {
                CompleteTask();
            }
            else if (InputHandler.Instance.AnyButton() && !InputHandler.Instance.LeftTrigger() && !InputHandler.Instance.RightTrigger())
            {
                FailTask();
            }
        }
    }
}
