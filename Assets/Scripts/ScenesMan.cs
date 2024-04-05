using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DentedPixel;

public class ScenesMan : MonoBehaviour
{
    public float wait;
    public GameObject circleOut, circleIn;
    public bool change = false;
    public string sceneName;
    void Start()
    {
        LeanTween.moveLocalX(circleOut, 1000, 1.5f).setEaseOutExpo();
    }
    void Update()
    {
        if (change && wait >= 0)
        {
            wait -= Time.deltaTime;
        }
    }
    public void ChangeScene(string Name)
    {
        change = true;
        LeanTween.moveLocalX(circleIn, 0, 1.5f).setEaseInExpo().setOnComplete(() => { SceneManager.LoadScene(Name); });
        sceneName = Name;
    }
}
