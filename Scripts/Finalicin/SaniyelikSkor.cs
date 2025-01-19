using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaniyelikSkor : MonoBehaviour
{
    public TextMeshProUGUI scoreTxet;
    public float scoreMiktari;
    public float saniyedeliArtis;
    void Start()
    {
        scoreMiktari = 0f;
        saniyedeliArtis = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxet.text = (int)scoreMiktari + " ";
        scoreMiktari += saniyedeliArtis * Time.deltaTime;
    }
}
