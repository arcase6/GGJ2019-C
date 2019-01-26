using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool grounded = true;
    public Mover mover;
    public Rigidbody2D rb;

    private void Reset()
    {
        mover = GetComponent<Mover>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Detect collision with floor
    void OnCollisionEnter2D(Collision2D hit)
    {
        Debug.Log("Hit detected");
        if (hit.gameObject.tag == "Floor")
        {
            grounded = true;
        }
    }

    // Detect collision exit with floor
    void OnCollisionExit2D(Collision2D hit)
    {
        Debug.Log("Leave detected");

        if (hit.gameObject.tag == "Floor")
        {
            grounded = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        grounded = true;

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            mover.ApplyHorizontalMovement(horizontalInput);
        }


        if (Input.GetButtonDown("Jump") && grounded)
        {
            mover.Jump();
            grounded = false;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (rb.velocity.y > 0)
            {
                mover.ReduceJump();
            }
        }
    }
}
