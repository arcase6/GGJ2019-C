using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Mover mover;
    public Rigidbody2D rb;
    public int maxJumps = 2;
    private int jumpsRemaining;
    [HideInInspector]
    public List<Interactable> availableInteractables = new List<Interactable>();
    [HideInInspector]
    public bool isBusyWithAnimation;
    [HideInInspector]
    public bool isHiding;
    public BoxCollider2D PlayerHeart;
    public CapsuleCollider2D MainCollider;
    public SpriteRenderer renderer;
    private Interactable previousInteractable;
    private float normalGravity;

    public void SetVisibilty(bool visibility)
    {
        PlayerHeart.enabled = visibility;
        
    }

    public void SetHiding(bool isHiding)
    {
        this.isHiding = isHiding;
        if (isHiding)
        {
            renderer.enabled = false;
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0;
            MainCollider.enabled = false;
        }
        else
        {
            renderer.enabled = true;
            rb.gravityScale = normalGravity;
            MainCollider.enabled = true;
        }
    }

    private void Reset()
    {
        mover = GetComponent<Mover>();
        rb = GetComponent<Rigidbody2D>();
        PlayerHeart = GetComponentInChildren<BoxCollider2D>();
        MainCollider = GetComponent<CapsuleCollider2D>();
        renderer = GetComponentInChildren<SpriteRenderer>();
    }

    


    // Start is called before the first frame update
    void Start()
    {
        jumpsRemaining = maxJumps;
        mover.OnGroundedChanged.AddListener(RefillJumps);
        normalGravity = rb.gravityScale;
    }

    void RefillJumps()
    {
        if (mover.grounded && rb.velocity.y < 2)
            jumpsRemaining = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && (availableInteractables.Count > 0 || isHiding))
        {
            if (!isHiding)
            {
                previousInteractable = availableInteractables.First();
                availableInteractables.First().InteractWith(this);
            }
            else
                previousInteractable.InteractWith(this);
            return;
        }
        if (!this.isHiding)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput != 0)
            {
                mover.ApplyHorizontalMovement(horizontalInput);
            }
            
            if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
            {
                jumpsRemaining--;
                mover.Jump();
                mover.grounded = false;
            }
            else if (Input.GetButtonUp("Jump"))
            {
                if (rb.velocity.y > 0)
                    mover.ReduceJump();              
            }
        }
        
    }
}
