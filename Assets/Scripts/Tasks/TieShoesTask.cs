using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieShoesTask : Task
{
    //[SerializeField] List<Buttons> firstButtonSet = new List<Buttons>();
    //[SerializeField] List<Buttons> secondButtonSet = new List<Buttons>();
    int totalButtons = 4;

    int buttonsPressed = 0;

    public override void BeginTask()
    {
        base.BeginTask();

        buttonsPressed = 0;

        print("Press the buttons in the correct sequence");
    }

    void Update()
    {
        if (taskBegun)
        {
            switch (buttonsPressed)
            {
                case 0:

                    print("Press LB");

                    if (InputHandler.Instance.LeftBumper())
                    {
                        buttonsPressed++;
                    }
                    else if (InputHandler.Instance.AnyButton())
                    {
                        FailTask();
                    }

                    break;

                case 1:

                    print("Press LT");

                    if (InputHandler.Instance.LeftTrigger())
                    {
                        buttonsPressed++;
                    }
                    else if (InputHandler.Instance.AnyButton())
                    {
                        FailTask();
                    }

                    break;

                case 2:

                    print("Press RB");

                    if (InputHandler.Instance.RightBumper())
                    {
                        buttonsPressed++;
                    }
                    else if (InputHandler.Instance.AnyButton())
                    {
                        FailTask();
                    }

                    break;

                case 3:

                    print("Press RT");

                    if (InputHandler.Instance.RightTrigger())
                    {
                        buttonsPressed++;
                    }
                    else if (InputHandler.Instance.AnyButton())
                    {
                        FailTask();
                    }

                    break;
            }

            if (buttonsPressed >= totalButtons)
            {
                CompleteTask();
            }
        }
    }
}
