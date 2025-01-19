using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateAndRotate : MonoBehaviour
{
    private float speed = 10;
    private float turnSpeed = 20;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * turnSpeed * Time.deltaTime);
        }
    }
}
