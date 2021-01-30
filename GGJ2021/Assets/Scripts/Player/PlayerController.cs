using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private void Awake()
    {
        tag = "Player";
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    void Move(Vector3 dir)
    {
        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);
        //transform.LookAt(Camera.main.transform.position, Vector3.up);
    }
}
