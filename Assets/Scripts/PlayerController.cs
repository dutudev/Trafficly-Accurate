using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed, brakingForce;
    public int dir;
    public Animator animator;
    public bool isIddle = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
    }

    void FixedUpdate()
    {
        Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 movement = inputDirection * speed;
        Vector2 newPosition = new Vector2(this.transform.position.x, this.transform.position.y) + movement;
        rb.MovePosition(newPosition);
        transform.Rotate(0, 0, (transform.rotation.z + Input.GetAxisRaw("Horizontal") + Input.GetAxisRaw("Vertical")) * 10);
        /*
        switch (dir)
        {
            case 1:
                rb.MovePosition(new Vector2(this.transform.position.x, this.transform.position.y + Input.GetAxisRaw("Vertical") * speed));
                RotatePlayer(1);
                break;
            case 2:
                rb.MovePosition(new Vector2(this.transform.position.x, this.transform.position.y + Input.GetAxisRaw("Vertical") * speed));
                RotatePlayer(2);
                break;
            case 3:
                rb.MovePosition(new Vector2(this.transform.position.x + Input.GetAxisRaw("Horizontal") * speed, this.transform.position.y));
                RotatePlayer(3);
                break;
            case 4:
                rb.MovePosition(new Vector2(this.transform.position.x + Input.GetAxisRaw("Horizontal") * speed, this.transform.position.y));
                RotatePlayer(4);
                break;

        }

        */
    }

    void RotatePlayer(int rotDir)
    {
        switch (rotDir)
        {
            case 1:
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                break;
            case 2:
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                break;
            case 3:
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                break;
            case 4:
                transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                break;

        }
    }
}
