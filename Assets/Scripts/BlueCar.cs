using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCar : MonoBehaviour
{
    public float rot, speed = 100f;
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rot * speed);
        rot += Time.deltaTime;
    }
}
