using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private Material interactMat;

    [SerializeField]
    private Material defaultMat;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip ambientSound;
    [SerializeField]
    private AudioClip interactSound;
    [SerializeField]
    private AudioClip completeSound;

    public bool complete;

    private void Start() {
        ObjectiveManager.instance.interactables.Add(GetComponent<Interactable>());
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1;
    }
    public void Interact()
    {
        GetComponent<MeshRenderer>().material = interactMat;
        complete = true;
        ObjectiveManager.instance.CheckObjectives();
        audioSource.clip = interactSound;
        audioSource.loop = true;
        audioSource.Play();     
    }

    public bool GetCompletion()
    {
        return complete;
    }

    public void SetDefault()
    {
        complete = false;
        audioSource.clip = ambientSound;
        GetComponent<MeshRenderer>().material = defaultMat;
    }
}
