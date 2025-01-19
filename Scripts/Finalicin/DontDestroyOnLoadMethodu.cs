using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadMethodu : MonoBehaviour
{
    public GameObject Image;
    void Start()
    {
        DontDestroyOnLoad(Image);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
