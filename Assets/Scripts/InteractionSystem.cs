using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField]
    private bool canInteract;

    private Collider currentInteraction;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Interactable"))
        {
            if(!other.GetComponent<Interactable>().complete)
            {
                currentInteraction = other;
                canInteract = true;
            }
            
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Interactable"))
        {
            canInteract = false;
        }
    }

    private void Update() {
         if(Input.GetKeyDown(KeyCode.Mouse0) && canInteract)
        {
            currentInteraction.GetComponent<Interactable>().Interact();
            canInteract = false;
        }
    }
}
