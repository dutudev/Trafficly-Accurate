using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GoalManagement goalManagement;


    void OnTriggerEnter2D(Collider2D collision)
    {
        goalManagement.TargetHit();
        this.gameObject.SetActive(false);
    }
}
