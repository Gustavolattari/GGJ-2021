using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D myRb;

    Vector2 movement;


   void Update()
    {
        MoveInput();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        myRb.velocity = movement;
    }
    void MoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement = new Vector2(x, y).normalized * moveSpeed;
    }
}
