using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bane : MonoBehaviour
{
    bool flag = false;
    float time=0;
    GameObject target;
    Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == true)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                Rigidbody2D r=target.GetComponent<Rigidbody2D>();
                r.AddForce(new Vector2(0, 1) * 800);
                flag = false;
                time = 0;
            }
        }
        else if (flag == false)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    anime.SetTrigger("idel");
                    time = 0;
                }
            }
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (flag == false && time==0)
            {
                flag = true;
                time = 0.18f;
                target = collision.gameObject;
                anime.SetTrigger("jump");
            }
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (flag == true)
            {
                flag = false;
            }
        }
    }

}
