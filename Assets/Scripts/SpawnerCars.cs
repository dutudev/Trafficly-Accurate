using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerCars : MonoBehaviour
{
    public int[] spawnersType;
    public GameObject[] spawnersLocation;

    public GameObject redCar;
    public GameObject yellowCar;
    public GameObject orangeCar;

    void Start()
    {
        spawnersType = new int[8];
        //8 spawners
        //int 1 type red, int 2 type yellow, int 3 type orange
        for (int i = 0; i < spawnersType.Length; i++)
        {
            int type = Random.Range(1, 4);
            spawnersType[i] = type;
            Debug.Log("Spawner " + i + " am tip " + type);
        }

        for (int i = 0; i < spawnersType.Length; i++)
        {
            if (spawnersType[i] == 1)
            {
                GameObject obj = (GameObject) Instantiate(redCar, spawnersLocation[i].transform.position, Quaternion.identity);

                if (i == 4 || i == 5)
                    obj.GetComponent<RedCar>().SetDirection(true, 2);
                else if (i == 6 || i == 7)
                    obj.GetComponent<RedCar>().SetDirection(true, 3);
                else if (i == 0 || i == 1)
                    obj.GetComponent<RedCar>().SetDirection(false, 1);
                else if (i == 2 || i == 3)
                    obj.GetComponent<RedCar>().SetDirection(false, 4);

            }
            else if (spawnersType[i] == 2)
            {
                GameObject obj = (GameObject)Instantiate(yellowCar, spawnersLocation[i].transform.position, Quaternion.identity);

                if (i == 4 || i == 5)
                    obj.GetComponent<YellowCar>().SetDirection(true, 2);
                else if (i == 6 || i == 7)
                    obj.GetComponent<YellowCar>().SetDirection(true, 3);

                else if (i == 0 || i == 1)
                    obj.GetComponent<YellowCar>().SetDirection(false, 1);
                else if (i == 2 || i == 3)
                    obj.GetComponent<YellowCar>().SetDirection(false, 4);

            }
            else if (spawnersType[i] == 3)
            {
                GameObject obj = (GameObject)Instantiate(orangeCar, spawnersLocation[i].transform.position, Quaternion.identity);

                if (i == 4 || i == 5)
                    obj.GetComponent<OrangeCar>().SetDirection(true, 2);
                else if (i == 6 || i == 7)
                    obj.GetComponent<OrangeCar>().SetDirection(true, 3);

                else if (i == 0 || i == 1)
                    obj.GetComponent<OrangeCar>().SetDirection(false, 1);
                else if (i == 2 || i == 3)
                    obj.GetComponent<OrangeCar>().SetDirection(false, 4);

            }
        }
    }

}
