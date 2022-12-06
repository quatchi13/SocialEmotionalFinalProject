using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushTeethTask : Task
{
    [SerializeField] float timeLimit = 10;
    [SerializeField] int targetButtonPressAmount = 50; 
    int bumperToPress = 0; // 0 is LB and 1 is RB
    int currentButtonPresses = 0;

    private void Update()
    {
        if (taskBegun)
        {
            print($"Bumpers Pressed: {currentButtonPresses}");
        }
    }

    public override void BeginTask()
    {
        base.BeginTask();

        bumperToPress = 0;
        currentButtonPresses = 0;

        print("Alternate LB and RB enough times within 10 seconds to successfully brush your teeth");

        StartCoroutine(StartTask());
    }

    IEnumerator StartTask()
    {
        float elasped = 0;
        currentButtonPresses = 0;

        while(elasped < timeLimit)
        {
            if (bumperToPress == 0 && InputHandler.Instance.LeftBumper())
            {
                currentButtonPresses++;

                bumperToPress = 1;
            }
            if (bumperToPress == 1 && InputHandler.Instance.RightBumper())
            {
                currentButtonPresses++;

                bumperToPress = 0;
            }

            elasped += Time.deltaTime;

            if (currentButtonPresses >= targetButtonPressAmount)
            {
                CompleteTask();
            }

            yield return null;
        }

        if (currentButtonPresses < targetButtonPressAmount)
        {
            FailTask();
        }

        yield return null;
    }
}
