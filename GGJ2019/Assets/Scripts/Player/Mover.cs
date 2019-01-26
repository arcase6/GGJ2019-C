using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Mover : MonoBehaviour
{
    public Rigidbody2D rb;
    public float MaxSpeed = 5;
    public int Acceleration = 1;
    public int Decceleration = 100;
    public float jumpTakeOffSpeed = 7;
    public bool grounded = true;
    public Animator MovementAnimator;
    public Transform feet;
    public UnityEvent OnGroundedChanged;

    private void Reset()
    {
        rb = GetComponent<Rigidbody2D>();
        MaxSpeed = 25;
        Acceleration = 25;
        jumpTakeOffSpeed = 7;
        MovementAnimator = GetComponentInChildren<Animator>();
        feet = GetComponentsInChildren<Transform>().Where(t => t.gameObject.name == "Feet").FirstOrDefault();
    }


    // Start is called before the first frame update
    void Start()
    {
        grounded = true;
        MovementAnimator = GetComponentInChildren<Animator>();

    }

    private void FixedUpdate()
    {
    }
    // Update is called once per 
    void Update()
    {
        bool almostStopped = rb.velocity.x < 1 && rb.velocity.x > -1;
        if (Input.GetAxis("Horizontal") == 0 && gameObject.tag == "Player" && grounded && !almostStopped)
        {
            Vector2 decceleration = new Vector2(Decceleration * Time.deltaTime, 0);
            if (rb.velocity.x > 0)
                decceleration = decceleration * -1;
            ApplyAcceleration(decceleration);
        }

        bool wasGrounded = grounded;
        for (int i = -1; i <= 1; i += 2)
        {
            grounded = Physics2D.RaycastAll(new Vector2(feet.position.x + i / 2, feet.position.y), new Vector2(0, -1.0f), 1.0f)
                .Where(h => h.collider != null)
                .Any(h => h.collider.gameObject.tag == "Floor");
            if (grounded)
                break;
        }
        if(wasGrounded != grounded)
        {
            OnGroundedChanged.Invoke();
        }
        MovementAnimator.SetBool("Ground", grounded);

        float velocity = rb.velocity.x;

        float moveBlend = Mathf.Abs(rb.velocity.x) / (MaxSpeed);
        if (moveBlend < 0) moveBlend = 0;
        if (moveBlend > 1) moveBlend = 1;

        MovementAnimator.SetFloat("velocity",velocity);
        MovementAnimator.SetFloat("moveBlend", moveBlend);
        Vector3 oldScale = MovementAnimator.transform.localScale;
        Vector3 newScale = new Vector3(Mathf.Abs(oldScale.x), oldScale.y, oldScale.z);
        if (velocity > 1)
            newScale.x = newScale.x * -1;
        if(!almostStopped)
        MovementAnimator.transform.localScale = newScale;
        float verticalSpeed = Mathf.Abs(rb.velocity.y);
        MovementAnimator.SetFloat("verticalSpeed", verticalSpeed);
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
        MovementAnimator.SetTrigger("Jump");
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
