using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float health = 300; 

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private Animator anim;
    public float dashSpeed;
    public float dashTime;
    private bool CanDash = true;
    public bool gameOver = false;
    public bool Block;
    private AudioSource playerrAudio;
    public AudioSource Walking;
    public AudioSource running;
    public AudioClip hitSound;
    public AudioClip hitingSound;
    public AudioClip swordSwingSound;
    public AudioClip walkSound;
    public GameObject vave1,vave2,vave3;
    public AudioSource music;
    public GameObject gameOverCanvas;
    

    void Start() 
    {
        anim = GetComponent<Animator>();
        health = 300;
        playerrAudio = GetComponent<AudioSource>();
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
        
    }

    void Update()
    {
        Movement(); //Movement metodu çağırıldı
        Animations(); //Animations metodu çağırıldı

        if(health <= 0) // Karakterin canı 0 ve altına indiğinde ölüm animasyonu oynasın ve gameOver değişkeni true değer döndürsün
        {
            anim.SetBool("death" , true);
            gameOver = true;
            gameOverCanvas.SetActive(true);
            StartCoroutine(TimeStop());


            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);
            }

        }

        if(transform.position.y > 7.372)
        {
            Vector3 newPosition = new Vector3(transform.position.x, 7.372f, transform.position.z);
            transform.position = newPosition;
        }


        if(Input.GetKeyDown(KeyCode.Space))
        {
            music.enabled = true;
        }
    }





    void Movement()
    {
        //Yürüme ve Dönme Kodu
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal,0,vertical).normalized;

        if(direction.magnitude >= 0.1f && gameOver == false)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle,0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);


            //Koşma Kodu
            if(Input.GetKey(KeyCode.LeftShift))
            {
                speed = 6;

            }
            else
            {
                speed = 3;
            }


            //Dash Kodu
            if(Input.GetKeyDown(KeyCode.LeftControl))
            {
                if(CanDash)
                {
                    StartCoroutine(Dash(moveDir));
                }
                
            }

            if (Input.GetMouseButton(1)) // Eğer fare sağ tuşuna basılı tutuluyorsa
            {
                Block = true;
            }
            else
            {
                Block = false;
            }

        }
    }


    //Karakterin Dash yapabilmesini sağlayan kod
    IEnumerator Dash(Vector3 moveDir)
    {

        if(CanDash)
        {
            CanDash = false;

            float startTime = Time.time;

            while(Time.time < startTime + dashTime)
            {
                controller.Move(moveDir * dashSpeed *Time.deltaTime);

                yield return null;
            }

            yield return new WaitForSeconds(1.5f);

            CanDash = true;
        }
    }



    //Animasyonlar
    void Animations()
    {

        //Yürüme Animasyonu
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("walk" , true);
            Walking.enabled = true;
        }
        else
        {
            anim.SetBool("walk" , false);
            Walking.enabled = false;
        }

        //Koşma Animasyonu
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Runing" , true);
            running.enabled = true;
            Walking.enabled = false;
        }
        else
        {
            anim.SetBool("Runing" , false);
            running.enabled = false;
        }

        //Dash Animasyonu
        if(Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetBool("Dash" , true);
        }
        else
        {
            anim.SetBool("Dash" , false);
        }

        
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("EnemyHand")) //Düşmanın eli karakterimize çarparsa karakterimizin canı azalsın ve hit animasyonu oynasın
        {
            health = health -10 ;
            anim.SetBool("hit" , true);
            playerrAudio.PlayOneShot(hitingSound, 5.0f);
            StartCoroutine(HitWait());
        }
    }

    private void OnTriggerEnter(Collider other) // Karakterimiz wave noktalarına grdiğinde waveler harekete geçsin
    {
        if(other.gameObject.CompareTag("Callwave1"))
        {
            vave1.SetActive(true);
        }
        else if(other.gameObject.CompareTag("Callwave2"))
        {
            vave2.SetActive(true);
        }
        else if(other.gameObject.CompareTag("Callwave3"))
        {
            vave3.SetActive(true);
        }    
    }
    IEnumerator HitWait()
    {
        yield return new WaitForSeconds(1.3f);
        anim.SetBool("hit" , false);
    }

    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(4f);
        Time.timeScale = 0;
    }
    
}
