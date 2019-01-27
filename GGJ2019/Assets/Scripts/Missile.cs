using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform target;
    Rigidbody2D _rigidbody;
    float life = 3;
    SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = new Vector2(0.0f, 8.0f);
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 sub = target.position - transform.position;
        Vector2 vec=_rigidbody.velocity;
        float cross=vec.x*sub.y - vec.y * sub.x;
        cross /= (vec.magnitude * sub.magnitude);
        if (cross >= 0.2f)
        {
            vec = Quaternion.Euler(0, 0, 5) * vec;
        }
        else if(cross <=-0.2f)
        {
            vec = Quaternion.Euler(0, 0, -5) * vec;
        }
        vec =vec* 1.4f;
        if (vec.magnitude >= 15.0f) vec=vec.normalized * 15.0f;
        _rigidbody.velocity = vec;
        float deg = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        Vector3 angles = transform.localEulerAngles;
        angles.z = deg-90;
        transform.localEulerAngles = angles;
        life -= Time.deltaTime;
        float a = life / 3.0f;
        if (a <= 0) a = 0;
        sp.color = new Color(1.0f, 1.0f, 1.0f, a);
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
