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
                Instantiate(redCar, spawnersLocation[i].transform.position, Quaternion.identity);
            else if (spawnersType[i] == 2)
                Instantiate(yellowCar, spawnersLocation[i].transform.position, Quaternion.identity);
            else if (spawnersType[i] == 3)
                Instantiate(orangeCar, spawnersLocation[i].transform.position, Quaternion.identity);
        }
    }

}
