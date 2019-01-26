using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D r;
    float x=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        r.velocity = new Vector2(x * 20.0f, r.velocity.y);

    }
}
