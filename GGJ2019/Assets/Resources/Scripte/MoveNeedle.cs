using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNeedle : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    bool flag = false;
    float life = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == false)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, new Vector2(0, -1.0f), 20.0f);
            foreach (var hit in hits)
            {
                if (hit.collider)
                {
                    if (hit.collider.tag == "Player")
                    {
                        _rigidbody.gravityScale = 2.5f;
                        flag = true;
                    }
                }
            }
        }
        if (flag == true)
        {
            life -= Time.deltaTime;
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }        
    }
}
