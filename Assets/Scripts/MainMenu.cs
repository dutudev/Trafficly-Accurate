using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public ScenesMan scenesMan;
    

    public void Play()
    {
        scenesMan.ChangeScene("Stage1");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
