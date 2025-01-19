using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject Wave1;
    public GameObject Wave2;
    public GameObject Wave3;

    public float waveCount =9;


    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waveCount == 8)
        {
            wall1.SetActive(false);
        }

        if(waveCount == 5)
        {
            wall2.SetActive(false);
        }

        if(waveCount == 0)
        {
            wall3.SetActive(false);
        }


    }
}
