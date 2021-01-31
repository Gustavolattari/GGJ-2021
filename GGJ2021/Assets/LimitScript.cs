using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitScript : MonoBehaviour
{
    LevelManager levelManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animal")
        {
            levelManager.animals.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
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
