using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerCanvas : MonoBehaviour
{
    public Transform cam;
    void LateUpdate()
    {
        transform.LookAt(cam);
    }
}
