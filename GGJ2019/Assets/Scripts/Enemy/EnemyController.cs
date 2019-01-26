using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public Vector2 TargetLocation;
    public Mover mover;
    public bool targetReached = false;
    public Rigidbody2D rb;
    public Vector2 PatrolPoint1;
    public Vector2 PatrolPoint2;
    public float DefaultPatrolOffset = 20;
    [HideInInspector]
    public Transform playerTransform;
    

    public void Reset()
    {
        mover = GetComponent<Mover>();
        rb = GetComponent<Rigidbody2D>();
        targetReached = false;
        PatrolPoint1 = new Vector2(rb.position.x - DefaultPatrolOffset,rb.position.y);
        PatrolPoint2 = new Vector2(rb.position.x + DefaultPatrolOffset,rb.position.y);
    }

    // Start is called before the first frame update
    void Start()
    {
        TargetLocation = PatrolPoint1;

    }

    // Update is called once per frame
    void Update()
    {
        
        //check to see if target reached
        if (!targetReached && TargetLocation != null)
        {
            float difference = TargetLocation.x - rb.position.x;
            mover.ApplyHorizontalMovement(difference);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
