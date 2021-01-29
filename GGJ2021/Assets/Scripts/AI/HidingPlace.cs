using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HidingPlace : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animal")
        {
            AnimalAI ai = other.gameObject.GetComponent<AnimalAI>();
            ai.setHiden(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
