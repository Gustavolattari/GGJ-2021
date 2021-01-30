using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerDetection : MonoBehaviour
{
    public bool playerInRange = false;
    public GameObject playerRef;
    Collider col;
    AnimalAI parentAI;

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Player")
        {
            parentAI.playerInRange = true;
            parentAI.playerRef = other.gameObject;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            parentAI.playerInRange = false;
        }
    }
    private void Awake()
    {
        col = GetComponent<Collider>();
        col.isTrigger = true;
        parentAI = transform.parent.GetComponent<AnimalAI>();
        if (!parentAI)
            Debug.LogError("Player Detection script expected AnimalAI on parent object");
    }
}
