using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Rigidbody2D rb;
    public float MaxSpeed = 5;
    public int Acceleration = 1;
    public float jumpTakeOffSpeed = 7;

    private void Reset()
    {
        rb = GetComponent<Rigidbody2D>();
        MaxSpeed = 50;
        Acceleration = 10;
        jumpTakeOffSpeed = 7;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceJump()
    {
        Vector2 newSpeed = rb.velocity;
        newSpeed.y = jumpTakeOffSpeed / 2;
        if(rb.velocity.y > newSpeed.y)
        rb.velocity = newSpeed;
    }

    public void Jump()
    {
        Vector2 newSpeed = rb.velocity;
        newSpeed.y = jumpTakeOffSpeed;
        rb.velocity = newSpeed;
    }

    public void ApplyHorizontalMovement(float horizontalInput)
    {
        Vector2 acceleration = new Vector2(Acceleration, 0);
        Vector2 currentSpeed = rb.velocity;
        //allow acceleration in the opposite direction
        if (horizontalInput < 0)
        {
            if (currentSpeed.x <= MaxSpeed * -1)
                return;
            acceleration *= -1;
        }
        else
        {
            if (currentSpeed.x >= MaxSpeed)
                return;
        }

        acceleration = acceleration * Time.deltaTime;
        ApplyAcceleration(acceleration);
    }

    public void ApplyAcceleration(Vector2 acceleration)
    {
        rb.velocity += acceleration;

    }
}
