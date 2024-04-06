using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using Cinemachine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class StartAnim : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;
    public PlayerController playerController;
    public Volume volume;
    public Vignette vignette;
    public ColorAdjustments colorAdjustments;
    public FilmGrain grain;

    void Start()
    {
        // Try to fetch the settings from the Volume's VolumeProfile
        if (volume.profile.TryGet<Vignette>(out var vign))
        {
            vignette = vign;
        }
        if (volume.profile.TryGet<ColorAdjustments>(out var colorAdj))
        {
            colorAdjustments = colorAdj;
        }
        if (volume.profile.TryGet<FilmGrain>(out var fg))
        {
            grain = fg;
        }
    }
    public void CameraAnim()
    {
        LeanTween.value(gameObject, 0f, .5f, 3f).setEaseOutExpo().setOnUpdate((float value) => { vignette.intensity.value = value; }).setOnComplete(() =>
        {
            LeanTween.value(gameObject, .5f, 0f, 3f).setEaseOutExpo().setOnUpdate((float value) => { vignette.intensity.value = value; });
        });
        LeanTween.value(gameObject, 0f, -180f, 3f).setEaseOutExpo().setOnUpdate((float value) => { colorAdjustments.saturation.value = value; }).setOnComplete(() =>
        {
            LeanTween.value(gameObject, -180f, 0f, 3f).setEaseOutExpo().setOnUpdate((float value) => { colorAdjustments.saturation.value = value; });
        });
        LeanTween.value(gameObject, 0f, 1f, 3f).setEaseOutExpo().setOnUpdate((float value) => { grain.intensity.value = value; }).setOnComplete(() =>
        {
            LeanTween.value(gameObject, 1f, 0f, 3f).setEaseOutExpo().setOnUpdate((float value) => { grain.intensity.value = value; });
        });
        LeanTween.value(gameObject, 5, 15, 3f).setEaseOutExpo().setOnUpdate((float value) => { VirtualCamera.m_Lens.OrthographicSize = value; }).setOnComplete(() =>
        {
            LeanTween.value(15, 5, 1.5f).setEaseOutExpo().setOnUpdate((float value) => { VirtualCamera.m_Lens.OrthographicSize = value; }).setOnComplete(() => { playerController.canMove = true; });
        });
    }

}
