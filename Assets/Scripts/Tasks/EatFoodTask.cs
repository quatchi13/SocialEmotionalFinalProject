using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFoodTask : Task
{
    [SerializeField] float inputHoldTime = 2;
    [SerializeField] float totalNumberOfInputs = 4;

    int analogInputsCompleted = 0;

    bool inputStarted;

    public override void BeginTask()
    {
        base.BeginTask();

        analogInputsCompleted = 0;
        inputStarted = false;

        print("Pull down and up and your right analog stick and hold in each position for 2 seconds");
    }

    void Update()
    {
        if (taskBegun)
        {
            if (analogInputsCompleted == 0 || analogInputsCompleted == 2)
            {
                if (!inputStarted && InputHandler.Instance.Aim().y <= -0.1f)
                {
                    inputStarted = true;

                    StartCoroutine(BeginHoldTime());
                }
            }
            if (analogInputsCompleted == 1 || analogInputsCompleted == 3)
            {
                if (!inputStarted && InputHandler.Instance.Aim().y >= 0.1f)
                {
                    inputStarted = true;

                    StartCoroutine(BeginHoldTime());
                }
            }

            if (analogInputsCompleted >= totalNumberOfInputs)
            {
                CompleteTask();
            }
        }
    }

    IEnumerator BeginHoldTime()
    {
        print("Started Holding Analog");

        float elasped = 0;

        while(elasped < inputHoldTime)
        {
            if (analogInputsCompleted == 0 || analogInputsCompleted == 2)
            {
                if (InputHandler.Instance.Aim().y > -0.1f)
                {
                    print("Cancelled Analog");

                    FailTask();

                    break;
                }
            }
            if (analogInputsCompleted == 1 || analogInputsCompleted == 3)
            {
                if (InputHandler.Instance.Aim().y < 0.1f)
                {
                    print("Cancelled Analog");

                    FailTask();

                    break;
                }
            }

            elasped += Time.deltaTime;

            yield return null;
        }

        analogInputsCompleted++;
        inputStarted = false;

        print("Analog Input Completed");

        yield return null;
    }
}
