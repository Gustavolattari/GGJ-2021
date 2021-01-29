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
        
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.A))
        {

        }
        if (Input.GetKey(KeyCode.D))
        {

        }
    }
}
