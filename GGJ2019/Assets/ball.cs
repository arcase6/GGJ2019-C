using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    float time = 3.0f;
    SpriteRenderer sp;
    Transform target;
    // Start is called before the first frame update

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Vector2 sub = (target.position - transform.position).normalized;
        _rigidbody.AddForce(sub * 800);
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        float a = time / 3.0f;
        if (a <= 0) a = 0;
        sp.color = new Color(1.0f, 1.0f, 1.0f, a);
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void targetset(Transform _target)
    {
        target = _target;
    }
}
