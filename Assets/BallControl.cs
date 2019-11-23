using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -3)
        {
            
            transform.position = startPos;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
