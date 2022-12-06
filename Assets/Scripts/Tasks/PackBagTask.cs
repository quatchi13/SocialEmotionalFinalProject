using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PackBagTask : Task
{
    [SerializeField] List<Buttons> buttons = new List<Buttons>();

    int buttonsPressed = 0;

    // Update is called once per frame
    void Update()
    {
        if (taskBegun)
        {
            switch (buttons[buttonsPressed])
            {
                case Buttons.A:

                    print("Press A");

                    icons[0].gameObject.SetActive(true);
                    icons[1].gameObject.SetActive(false);
                    icons[2].gameObject.SetActive(false);
                    icons[3].gameObject.SetActive(false);

                    if (InputHandler.Instance.Interact())
                    {
                        buttonsPressed++;
                    }
                    else if (InputHandler.Instance.AnyButton())
                    {
                        FailTask();
                    }

                    break;

                case Buttons.B:

                    print("Press B");

                    icons[0].gameObject.SetActive(false);
                    icons[1].gameObject.SetActive(true);
                    icons[2].gameObject.SetActive(false);
                    icons[3].gameObject.SetActive(false);

                    if (InputHandler.Instance.TaskButton2())
                    {
                        buttonsPressed++;
                    }
                    else if (InputHandler.Instance.AnyButton())
                    {
                        FailTask();
                    }

                    break;

                case Buttons.X:

                    print("Press X");

                    icons[0].gameObject.SetActive(false);
                    icons[1].gameObject.SetActive(false);
                    icons[2].gameObject.SetActive(true);
                    icons[3].gameObject.SetActive(false);

                    if (InputHandler.Instance.TaskButton1())
                    {
                        buttonsPressed++;
                    }
                    else if (InputHandler.Instance.AnyButton())
                    {
                        FailTask();
                    }

                    break;

                case Buttons.Y:

                    print("Press Y");

                    icons[0].gameObject.SetActive(false);
                    icons[1].gameObject.SetActive(false);
                    icons[2].gameObject.SetActive(false);
                    icons[3].gameObject.SetActive(true);

                    if (InputHandler.Instance.TaskButton3())
                    {
                        buttonsPressed++;
                    }
                    else if (InputHandler.Instance.AnyButton())
                    {
                        FailTask();
                    }

                    break;
            }

            if (buttonsPressed >= buttons.Count)
            {
                CompleteTask();
            }
        }
    }

    public override void BeginTask()
    {
        base.BeginTask();

        buttonsPressed = 0;

        print("Press the correct buttons to pack your bag successfully");
    }
}
