using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        iTween.MoveUpdate(this.gameObject, iTween.Hash("position", new Vector3(target.position.x, 3.3f, -9.88591f), "time", 2.0f));
    }
}
