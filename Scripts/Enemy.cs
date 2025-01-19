using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    private float enemyHealth = 150;
    public Slider healthBar;
    public Transform hedef;
    float attackIndex;
    NavMeshAgent agent;
    public float mesafe;
    public GameObject RightDamageHand;
    public GameObject LeftDamageHand;
    CapsuleCollider colliderWapeonRight;
    CapsuleCollider colliderWapeonLeft;
    private AudioSource playerrAudio;
    public AudioClip hitSound;
    public AudioClip swordSwingSound;
    bool isEnemyDead = false;


    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        playerrAudio = GetComponent<AudioSource>();

        colliderWapeonRight = RightDamageHand.GetComponent<CapsuleCollider>();
        colliderWapeonLeft = LeftDamageHand.GetComponent<CapsuleCollider>();
    

        colliderWapeonRight.enabled = false;
        colliderWapeonLeft.enabled = false;


    }

    void Update()
    {

        anim.SetFloat("hiz", agent.velocity.magnitude);

        mesafe = Vector3.Distance(transform.position, hedef.position);
        
        agent.enabled = true;
        agent.destination = hedef.position;

        if(mesafe<3)
        {
            attackIndex = Random.Range(0,3);
            anim.SetFloat("attackIndex", attackIndex);
            anim.SetTrigger("Saldir");
        }
        else
        {
            anim.SetBool("EnemyAttacl" , false);
        }

        if(enemyHealth <=0 && !isEnemyDead)
        {
            agent.enabled = false;
            anim.SetBool("death", true);
            StartCoroutine(DeathDestroy());

            isEnemyDead = true;
        }   
         healthBar.value = enemyHealth;
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Kilic"))
        {
            playerrAudio.PlayOneShot(hitSound, 5.0f);
        }
        if(other.gameObject.CompareTag("Kilic"))
        {
            anim.SetBool("EnemyHit" , true);
            enemyHealth = enemyHealth - 30;
            StartCoroutine(HitStop());
        }
        
    }


    IEnumerator DeathDestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    IEnumerator HitStop()
    {
        yield return new WaitForSeconds(2);
        anim.SetBool("EnemyHit" , false);
    }

    public void AttackStartRightHand()
    {
        colliderWapeonRight.enabled = true;
    }
    public void AttackEndRightHand()
    {
        colliderWapeonRight.enabled = false;
    }


    public void AttackStartLeftHand()
    {
        colliderWapeonLeft.enabled = true;
    }
    public void AttackEndLeftHand()
    {
        colliderWapeonLeft.enabled = false;
    }
}