using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed, brakingForce;
    public int dir;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(transform.up);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0 && Input.GetKey(KeyCode.W))
        {
            dir = 1;
        }
        else if (Input.GetAxisRaw("Vertical") < 0 && Input.GetKey(KeyCode.S))
        {
            dir = 2;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetKey(KeyCode.A))
        {
            dir = 3;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetKey(KeyCode.D))
        {
            dir = 4;
        }
    }
    void FixedUpdate()
    {
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
                transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                break;
            case 4:
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                break;

        }
    }
}
