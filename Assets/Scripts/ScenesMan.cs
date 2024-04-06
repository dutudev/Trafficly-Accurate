using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DentedPixel;

public class ScenesMan : MonoBehaviour
{
    public float wait;
    public GameObject circleOut, circleIn, image;
    public bool change = false;
    public string sceneName;
    public StartAnim anim;

    public static ScenesMan Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        LeanTween.scale(image, new Vector3(3, 3, 3), 2f).setEaseInOutExpo().setOnComplete(() =>
        {
            LeanTween.scale(image, new Vector3(0, 0, 0), .5f).setEaseInExpo().setOnComplete(() => { 
                LeanTween.moveLocalX(circleOut, 1000, 1.5f).setEaseOutExpo();
                if(SceneManager.GetActiveScene().ToString() != "Main Menu")
                {
                    anim.CameraAnim();
                }
            });
        });
        
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
