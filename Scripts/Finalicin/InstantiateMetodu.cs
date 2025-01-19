using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMetodu : MonoBehaviour
{
    public GameObject nesne;
    Vector3 spawnPos = new Vector3(-1.02476549f,6.49296093f-26.9493542f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(nesne, spawnPos, transform.rotation);
        }
    }
}
