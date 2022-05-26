using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 speed = new Vector2(50, 50);
    private Vector3 movement;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        this.movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
        this.rb.velocity = new Vector2(movement.x, movement.y);
    }
}
