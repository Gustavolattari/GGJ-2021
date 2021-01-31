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

    private Animator anim;
    private AudioSource audiosource;
    Rigidbody rb;

    private void Awake()
    {
        tag = "Player";
        anim = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
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
        bool moved = false;
        Vector3 moveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            //Move(Vector3.left);
            moveDir += Vector3.left;
            this.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.z));
            moved = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //Move(Vector3.right);
            moveDir += Vector3.right;
            this.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
            moved = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            //Move(Vector3.forward);
            moveDir += Vector3.forward;
            moved = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Move(Vector3.back);
            moveDir += Vector3.back;
            moved = true;
        }
        Move(moveDir);
        if (!moved)
        {
            Stop();
        }
    }

    void Run()
    {
        anim.SetBool("run", true);
    }

    public void WalkSound()
    {
         audiosource.Play();
    }
    void Stop()
    {
        anim.SetBool("run", false);
        rb.velocity = Vector3.zero;
    }

    void Move(Vector3 dir)
    {
        Run();
        rb.velocity = dir.normalized * moveSpeed;   
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
