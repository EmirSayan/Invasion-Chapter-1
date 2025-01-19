using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class VideoPlayerController1 : MonoBehaviour
{
    private Tower towerScript;
    public AudioSource music;
    public GameObject videoPlayerCanvas2;

    void Start()
    {
       // videoPlayerCanvas2.SetActive(false);
       towerScript = GameObject.Find("Tower").GetComponent<Tower>();
    }
    private void Update() 
    {
        if(towerScript.towerFall == true)
        {
            videoPlayerCanvas2.SetActive(true);
            music.enabled = false;
        }
    }
}