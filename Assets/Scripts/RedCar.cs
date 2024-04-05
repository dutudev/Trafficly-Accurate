using System.Collections;
using UnityEngine;

public class RedCar : MonoBehaviour
{
    public Transform transformRed;
    public GameObject target;
    public float movementSpeed = 8f;
    public int directionFacing; //Declare This On Scene
    //1 forward, 2 left, 3 right, 4 backwards
    public bool detectedPlayer = false;



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
        if (target.transform.position.y >= this.transform.position.y)
            detectedPlayer = true;

        if (detectedPlayer)
            Move(directionFacing);
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
}
