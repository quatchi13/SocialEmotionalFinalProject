using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    
    public static ObjectiveManager instance;

    public GameObject player;

    [SerializeField]
    public List<Interactable> interactables;

    public GameObject camEffect;

    public bool dayComplete;

    [SerializeField] Transform spawnpoint;
    [SerializeField] TextMeshProUGUI dayText;

    int currentDay = 1;
    
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    public void CheckObjectives()
    {
        dayComplete = true;

        for (int count = 0; count < interactables.Count; count ++)
        {
            if(!interactables[count].GetCompletion())
            {
                dayComplete = false;
            }
        }

        if (dayComplete)
        {
            EndDay();
        }
    }

    public void EndDay()
    {
        for(int count = 0; count < interactables.Count; count ++)
        {
            interactables[count].SetDefault();
        }

        WorsenVision();
        Debug.Log("Day Ended");

        player.transform.position = spawnpoint.position;

        currentDay++;
        dayText.text = $"Day {currentDay}";
    }

    public void WorsenVision()
    {
        Color color = camEffect.GetComponent<MeshRenderer>().material.color;
        color.a += 0.2f; 
        camEffect.GetComponent<MeshRenderer>().material.color = color;
    }
}
