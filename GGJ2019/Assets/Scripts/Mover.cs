using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Rigidbody2D rb;
    public float MaxSpeed = 5;
    public int Acceleration = 1;
    public float jumpTakeOffSpeed = 7;
    public bool grounded = true;

    private void Reset()
    {
        rb = GetComponent<Rigidbody2D>();
        MaxSpeed = 25;
        Acceleration = 25;
        jumpTakeOffSpeed = 7;
    }


    // Start is called before the first frame update
    void Start()
    {
        grounded = true;
    }

    private void FixedUpdate()
    {
    }
    // Update is called once per 
    void Update()
    {
        for (int i = -1; i <= 1; i += 2)
        {
            grounded = Physics2D.RaycastAll(new Vector2(transform.position.x + i / 2, transform.position.y), new Vector2(0, -1.0f), 1.0f)
                .Where(h => h.collider != null)
                .Any(h => h.collider.gameObject.tag == "Floor");
            if (grounded)
                break;
        }
    }

    public void ReduceJump()
    {
        Vector2 newSpeed = rb.velocity;
        newSpeed.y = jumpTakeOffSpeed / 2;
        if (rb.velocity.y > newSpeed.y)
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
        if (!grounded)
            acceleration.x /= 2;
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
