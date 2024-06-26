using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed, brakingForce, switchCooldown;
    // 1-d 2-r 3-h
    public int dir, selected = 1;
    public Animator animator;
    public bool isIddle = true, canMove = false, started = false;
    public RectTransform select, d, r, h;
    private Vector2 inputDirection;
    public ParticleSystem crash1, moveParticle;
    public GameObject crash;
    public GameObject SwearWords;
    public AudioSource giberish, boom;
    public SpriteRenderer sprite;
    
    public static PlayerController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        animator = GetComponent<Animator>();
        switchCooldown = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxisRaw("Vertical") > 0 && Input.GetKeyDown(KeyCode.W))
        {
            isIddle = false;
            dir = 1;
            animator.SetBool("isMoving", true);
            animator.SetBool("isReverse", false);
        }
        else if (Input.GetAxisRaw("Vertical") < 0 && Input.GetKeyDown(KeyCode.S))
        {
            isIddle = false;
            dir = 2;
            animator.SetBool("isReverse", true);
            animator.SetBool("isMoving", false);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetKeyDown(KeyCode.A))
        {
            isIddle = false;
            dir = 3;
            animator.SetBool("isMoving", true);
            animator.SetBool("isReverse", false);

        }
        else if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetKeyDown(KeyCode.D))
        {
            isIddle = false;
            dir = 4;
            animator.SetBool("isMoving", true);
            animator.SetBool("isReverse", false);

        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            isIddle = true;

        }

        if (isIddle)
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isReverse", false);
            animator.SetBool("isIdle", true);
        }
        /* if (Input.GetAxisRaw("Fire2") == 1 && switchCooldown <= 0f)
         {
             if(selected >= 3)
             {
                 selected = 1;
             }
             else
             {
                 selected++;
             }
             switchCooldown = 0.25f;
             AnimateSelect();
         }
         if (Input.GetAxisRaw("Fire1") == 1 && switchCooldown <= 0f)
         {
             if (selected <= 1)
             {
                 selected = 3;
             }
             else
             {
                 selected--;
             }
             switchCooldown = 0.25f;
             AnimateSelect();
         }

         switchCooldown -= Time.deltaTime;*/
        if (!isIddle)
        {
            particleMove();
        }
        else
        {
            particleMoveStop();
        }
    }

 /*   void AnimateSelect()
    {
        
        switch (selected)
        {
            case 1:
                LeanTween.value(gameObject, select.anchoredPosition.x, d.anchoredPosition.x, 0.2f).setEaseInOutExpo().setOnUpdate((float val) =>
                {
                    select.anchoredPosition = new Vector2(val, -215.9f);
                });
                break;
            case 2:
                LeanTween.value(gameObject, select.anchoredPosition.x, r.anchoredPosition.x, 0.2f).setEaseInOutExpo().setOnUpdate((float val) =>
                {
                    select.anchoredPosition = new Vector2(val, -215.9f);
                });
                break;
            case 3:
                LeanTween.value(gameObject, select.anchoredPosition.x, h.anchoredPosition.x, 0.2f).setEaseInOutExpo().setOnUpdate((float val) => { 
                    select.anchoredPosition = new Vector2(val, -215.9f);
                });
                break;
        }
    } */
    void particleMove()
    {
        if(!started)
        {
            moveParticle.Play();
            started = true;
        }
    }
    void particleMoveStop()
    {
        if (started)
        {
            moveParticle.Stop();
            started = false;
        }
    }
    void FixedUpdate()
    {
        if (canMove)
        {   
            inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            Vector2 movement = inputDirection * speed;
            Vector2 newPosition = new Vector2(this.transform.position.x, this.transform.position.y) + movement;
            rb.MovePosition(newPosition);
            //  transform.Rotate(0, 0, (transform.rotation.z + Input.GetAxisRaw("Horizontal") + Input.GetAxisRaw("Vertical")) * 10);
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) >= Mathf.Abs(Input.GetAxisRaw("Horizontal")))
            {
                if(Input.GetAxisRaw("Vertical") >= 0)
                {
                    RotatePlayer(1);
                }
                else
                {
                    RotatePlayer(2);
                }
                
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                RotatePlayer(4);
            }
            else
            {
                RotatePlayer(3);
            }
        }
        
    }

    void RotatePlayer(int rotDir)
    {
        switch (rotDir)
        {
            case 1:
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                break;
            case 2:
                transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                break;
            case 3:
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                break;
            case 4:
                transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                break;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            
            ScenesMan.Instance.ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        if (other.gameObject.CompareTag("Danger"))
        {
            crash1.Play();
            boom.Play();
            sprite.enabled = false;
            ScenesMan.Instance.ChangeScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public IEnumerator SwearWord()
    {
        int chance = Random.Range(1, 100);
        if (chance <= 40)
        {
            SwearWords.SetActive(true);
            giberish.pitch = Random.Range(0.9f, 1.1f);
            giberish.Play();
        }
        yield return new WaitForSeconds(1);
        SwearWords.SetActive(false);

    }

}
