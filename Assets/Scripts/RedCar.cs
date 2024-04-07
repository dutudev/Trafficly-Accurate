using System.Collections;
using UnityEngine;

public class RedCar : MonoBehaviour
{
    public Transform transformRed;
    public GameObject target;
    public float movementSpeed = 8f;
    public int directionFacing; //Declare This On Scene
    //1 forward, 2 left, 3 right, 4 backwards
    public bool detectedPlayer = false, carSound = false;
    public AudioSource honk;

    private float threshold = 1f;

    public bool sides;
    public int whatSide; //1 left, 2 right



    void Awake()
    {
        transformRed = GetComponent<Transform>();

        //Find Player Game Object
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        //Rotate Sprite
        switch (directionFacing)
        {
            case 2:
                transformRed.Rotate(new Vector3(0f, 0f, 1f) * 90);
                break;
            case 3:
                transformRed.Rotate(new Vector3(0f, 0f, 1f) * 270);
                break;
            case 4:
                transformRed.Rotate(new Vector3(0f, 0f, 1f) * 180);
                break;
            default:
                break;
        }
    }


    void Update()
    {
        if (directionFacing == 1)
        {
            if (whatSide == 1)
            {
                if (target.transform.position.x - threshold <= this.transform.position.x)
                    detectedPlayer = true;
            }
            else if (whatSide == 2)
            {
                if (target.transform.position.x + threshold >= this.transform.position.x)
                    detectedPlayer = true;
            }
        }

        else if (directionFacing == 2)
        {
            if (target.transform.position.y >= this.transform.position.y)
                detectedPlayer = true;
        }

        else if (directionFacing == 3)
        {
            if (target.transform.position.y <= this.transform.position.y)
                detectedPlayer = true;
        }

        else if (directionFacing == 4)
        {
            if (whatSide == 1)
            {
                if (target.transform.position.x - threshold <= this.transform.position.x)
                    detectedPlayer = true;
            }
            else if (whatSide == 2)
            {
                if (target.transform.position.x + threshold >= this.transform.position.x)
                    detectedPlayer = true;
            }
        }

        if (detectedPlayer)
        {
            Move(directionFacing);

            if (!carSound)
            {
                StartCoroutine(PlayerController.Instance.SwearWord());
                honk.dopplerLevel = Random.Range(1f, 5f);
                honk.pitch = Random.Range(0.6f, 1.5f);
                honk.Play();
                carSound= true;
            }
        }
            

    }

    

    public void Move(int direction)
    {
        if (direction == 1)
        {
            //Add rotation
            transformRed.position += new Vector3(0f, movementSpeed * Time.deltaTime, 0f);
        }

        else if (direction == 2)
        {
            transformRed.position += new Vector3(-movementSpeed * Time.deltaTime, 0f, 0f);
        }

        else if (direction == 3)
        {
            transformRed.position += new Vector3(movementSpeed * Time.deltaTime, 0f, 0f);
        }

        else if (direction == 4)
        {
            transformRed.position += new Vector3(0f, -movementSpeed * Time.deltaTime, 0f);
        }
    }

    //Set Direction And Side Of Movement At Spawn
    public void SetDirection(bool whatSide, int whatDir)
    {
        directionFacing = whatDir;
        sides = whatSide;

    }
}
