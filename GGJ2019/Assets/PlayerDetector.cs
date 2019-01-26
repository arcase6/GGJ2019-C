using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public Animator enemyController;
    public EnemyController enemy;
    public BoxCollider2D[] colliders;
    bool playerIsDetected = false;
    private void Reset()
    {
        enemyController = GetComponentInParent<Animator>();
        colliders = GetComponents<BoxCollider2D>();
        enemy = GetComponentInParent<EnemyController>();
    }


    public void Start()
    {
        
    }

    public void Update()
    {
        Vector3 newScale = enemy.rb.velocity.x < 0 ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
        if (transform.localScale != newScale)
            transform.localScale = newScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!playerIsDetected && collision.gameObject.tag == "PlayerHeart")
        {
            playerIsDetected = true;
            try
            {
                enemy.playerTransform = collision.GetComponentInParent<Transform>();
            }catch(Exception e)
            {

            }
            enemyController.SetTrigger("PlayerFound");
            foreach(BoxCollider2D collider in colliders)
            {
                collider.enabled = !collider.enabled; //swap to larger collider to make harder to lose
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (playerIsDetected && collision.gameObject.tag == "PlayerHeart")
        {
            playerIsDetected = false;
            enemyController.SetTrigger("PlayerLost");
            foreach (BoxCollider2D collider in colliders)
            {
                collider.enabled = !collider.enabled; //swap to larger collider to make harder to lose
            }
        }
    }
}
