using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    List<GameObject> hidingPlaces;
    List<GameObject> usedHidingPlaces;

    private void Awake()
    {
        hidingPlaces = new List<GameObject>();
        usedHidingPlaces = new List<GameObject>();
        HidingPlace[] arr = GameObject.FindObjectsOfType<HidingPlace>();
        for (int i = 0; i < arr.Length; i++)
        {
            hidingPlaces.Add(arr[i].gameObject);
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

    public GameObject GetHidingPlace()
    {
        int rand = Random.Range(0, hidingPlaces.Count - 1);//returns a random hiding place in the list
        GameObject reference = hidingPlaces[rand];
        usedHidingPlaces.Add(reference);
        hidingPlaces.RemoveAt(rand);
        return reference;
    }//returns a random hiding place
}
