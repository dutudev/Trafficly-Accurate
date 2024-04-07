using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public ScenesMan scenesMan;
    

    public void Play()
    {
        scenesMan.ChangeScene("Tutorial");
    }
    public void PlayGame()
    {
        scenesMan.ChangeScene("Stage1");
    }

    public void Shop()
    {
        scenesMan.ChangeScene("Shop");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
