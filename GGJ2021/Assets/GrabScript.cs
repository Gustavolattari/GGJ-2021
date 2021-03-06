using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    public GameObject bubble;

    PlayerController controller;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animal")
        {
            controller.animals.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Animal")
        {
            controller.animals.Remove(other.gameObject);
        }
    }

    private void Awake()
    {
        controller = transform.parent.GetComponent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.animalCount > 0)
        {
            if (bubble.activeSelf == false)
            {
                controller.BubbleSound();
            }
            bubble.SetActive(true);
        }
        else
            bubble.SetActive(false);
    }
}
