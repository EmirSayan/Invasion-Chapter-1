using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class VideoPlayerController : MonoBehaviour
{
    public GameObject videoPlayerCanvas;
    public AudioSource music;
    private Tower towerScript;

    void Start()
    {
        towerScript = GameObject.Find("Tower").GetComponent<Tower>();
        music.enabled = false;
    }
    private void Update() 
    {
        StartCoroutine(StopVideo());
        if(towerScript.towerFall == true)
        {
            music.enabled = false;
        }
    }

    IEnumerator StopVideo()
    {
        yield return new WaitForSeconds(65);
        videoPlayerCanvas.SetActive(false);
        music.enabled = true;
    }
}