using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalManagement : MonoBehaviour
{
    public GameObject[] targets;
    public float cooldown;
    public TMP_Text stateText;
    // 1-intermission; 2-in round
    public int state, lastTarget = -1, curTarget, targetsNeeded, targetsHit;
    void Start()
    {
        cooldown = 5f;
        state = 1;
        targetsNeeded = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 1)
        {
            cooldown -= Time.deltaTime;
            if (cooldown < 0)
            {
                state = 2;
                SetTarget();
            }
            if (targetsHit == 0)
            {
                stateText.text = "Getting there!";
            }
            else
            {
                stateText.text = "Targets hit : " + targetsHit + " / " + targetsNeeded;
            }
            
        }
        else
        {
            stateText.text = "Targets hit : " + targetsHit + " / " + targetsNeeded;
        }
        
    }
    void SetTarget()
    {
        curTarget = Random.Range(0, targets.Length);
        while (curTarget == lastTarget)
        {
            curTarget = Random.Range(0, targets.Length);
        }
        targets[curTarget].SetActive(true);
    }
    public void TargetHit()
    {
        lastTarget = curTarget;
        curTarget = -1;
        state = 1;
        cooldown = 5f;
        targetsHit++;
        if(targetsNeeded == targetsHit)
        {
            // go next intersection (scene)
        }
    }
}
