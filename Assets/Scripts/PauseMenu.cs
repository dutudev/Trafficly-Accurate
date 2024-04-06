using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject Panel;
    public bool isPaused = false;
    public ScenesMan scenesMan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                isPaused = true;
                Panel.SetActive(true);
                Time.timeScale = 0;
            }else
            {
                isPaused = false;
                Panel.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void UnPause()
    {
        isPaused = false;
        Panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        scenesMan.ChangeScene("Main Menu");
    }
}
