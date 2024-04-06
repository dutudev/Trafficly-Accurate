using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using Cinemachine;

public class StartAnim : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.value(gameObject, 10, 18, 3f).setEaseOutExpo().setOnUpdate((float value) => { VirtualCamera.m_Lens.OrthographicSize = value; }).setOnComplete(() =>
        {
            LeanTween.value(18, 10, 3f).setEaseOutExpo().setOnUpdate((float value) => { VirtualCamera.m_Lens.OrthographicSize = value; }).setOnComplete(() => { playerController.canMove = true; });
        });
    }

}
