using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Mover mover;
    public Rigidbody2D rb;

    private void Reset()
    {
        mover = GetComponent<Mover>();
        rb = GetComponent<Rigidbody2D>();
    }

    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            mover.ApplyHorizontalMovement(horizontalInput);
        }


        if (Input.GetButtonDown("Jump") && mover.grounded)
        {
            mover.Jump();
            mover.grounded = false;
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
