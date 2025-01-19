using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WepoanController : MonoBehaviour
{
    bool isStafe = false;
    Animator anim;
    BoxCollider colliderWapeon;
    bool canAtack = true;
    private AudioSource playerrAudio;
    public AudioClip hitSound;
    public AudioClip swordSwingSound;

    private ThirdPersonController playerScript;

    float attackIndex;

    public GameObject handWapeon;
    public GameObject backWapeon;
    private ThirdPersonController thirdPersonController;

    void Start()
    {
        anim = GetComponent<Animator>();
        colliderWapeon = handWapeon.GetComponent<BoxCollider>();
        colliderWapeon.enabled = false;
        playerrAudio = GetComponent<AudioSource>();
        thirdPersonController = GameObject.Find("Solider").GetComponent<ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("IS" , isStafe);

        if(Input.GetKeyDown(KeyCode.F)) //Kılıç kuşanma
        {
            isStafe = !isStafe;
        }


        if(Input.GetKeyDown(KeyCode.Mouse0) && isStafe == true && canAtack == true && thirdPersonController.gameOver == false)
        {
            attackIndex = Random.Range(0,3);
            anim.SetFloat("attackIndex", attackIndex);
            anim.SetTrigger("Saldir");
        }

        if(Input.GetKey(KeyCode.Mouse1) && isStafe == true)
        {
            anim.SetBool("Block" , true);
        }
        else
        {
            anim.SetBool("Block" , false);
        }
    }

    void Equip()
    {
        backWapeon.SetActive(false);
        handWapeon.SetActive(true);
    }

    void Unequip()
    {
        backWapeon.SetActive(true);
        handWapeon.SetActive(false);
    }

    public void AttackStart()
    {
        colliderWapeon.enabled = true;
    }

    public void AttackEnd()
    {
        colliderWapeon.enabled = false;
    }

}
