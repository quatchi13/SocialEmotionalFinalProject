using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField]
    private bool canInteract;

    private Collider currentInteraction;

    bool anyTaskActive;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Interactable"))
        {
            if(!other.GetComponent<Interactable>().complete)
            {
                currentInteraction = other;
                canInteract = true;
            }  
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Interactable"))
        {
            canInteract = false;
        }
    }

    private void Update() 
    {
        anyTaskActive = false;

        foreach (Task task in FindObjectsOfType<Task>())
        {
            if (task.IsTaskActive())
            {
                anyTaskActive = true;
            }
        }

        if (InputHandler.Instance.Interact() && canInteract && !anyTaskActive)
        {
            currentInteraction.GetComponent<Interactable>().Interact();
            canInteract = false;
        }
    }

    public bool IsAnyTaskActive()
    {
        return anyTaskActive;
    }
}
