using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaranceballMaker : MonoBehaviour
{
    public GameObject ball;
    float time = 0.0f;
    public Transform target;
    // Start is called before the first frame update
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(target.position, 0.5f);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(target.position, transform.position);
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            GameObject obj=Instantiate(ball, transform.position, Quaternion.identity);
            ball b = obj.GetComponent<ball>();
            b.targetset(target);
            time = 3.0f;
        }

    }
}
