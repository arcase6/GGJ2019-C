using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Mover mover;
    public Rigidbody2D rb;
    [HideInInspector]
    public List<Interactable> availableInteractables = new List<Interactable>();
    [HideInInspector]
    public bool isBusyWithAnimation;
    [HideInInspector]
    public bool isHiding;
    public BoxCollider2D PlayerHeart;
    public CapsuleCollider2D MainCollider;
    private Interactable previousInteractable;

    public void SetVisibilty(bool visibility)
    {
        PlayerHeart.enabled = visibility;
        
    }

    public void SetHiding(bool isHiding)
    {
        this.isHiding = isHiding;
        if (isHiding)
        {
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0;
            MainCollider.enabled = false;
        }
        else
        {
            rb.gravityScale = 1;
            MainCollider.enabled = true;
        }
    }

    private void Reset()
    {
        mover = GetComponent<Mover>();
        rb = GetComponent<Rigidbody2D>();
        PlayerHeart = GetComponentInChildren<BoxCollider2D>();
        MainCollider = GetComponent<CapsuleCollider2D>();
    }

    


    // Start is called before the first frame update
    void Start()
    {

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
            
            if (Input.GetButtonDown("Jump") && mover.grounded)
            {
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
