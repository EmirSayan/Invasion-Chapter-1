using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 kameraMesafe = new Vector3(0,3.48f,-6);
    void Start()
    {
        
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + kameraMesafe ;
    }
}
