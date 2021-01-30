using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int score = 0;

    [SerializeField]
    private float moveSpeed;
    
    [HideInInspector]
    public  List<GameObject> animals = new List<GameObject>();
    [HideInInspector]
    public int animalCount { get { return animals.Count; } }

    private void Awake()
    {
        tag = "Player";
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            RemoveAnimal(0);
        }
    }

    void Move(Vector3 dir)
    {
        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);
        //transform.LookAt(Camera.main.transform.position, Vector3.up);
    }



    public void RemoveAnimal(int index)
    {
        if (animals.Count <= 0 || !animals[index])
            return;
        AnimalAI critter = animals[index].GetComponent<AnimalAI>();
        if(critter != null)
        {
            Destroy(animals[index]);
            animals.RemoveAt(index);
            // Add score from animal script here
            score += 10;
        }
    }

    public int UpdateScore()
    {
        return score;
    }
}
