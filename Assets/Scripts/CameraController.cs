using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    CinemachineVirtualCamera VirtualCamera;
    CinemachineBasicMultiChannelPerlin noise;
    void Start()
    {
        VirtualCamera = GetComponent<CinemachineVirtualCamera>();
        noise = VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void shake(float duration = 0.1f, float amplitude = 0.5f, float frecuency = 20)
    {
        StopAllCoroutines();
        StartCoroutine(AppluNoise(duration, amplitude, frecuency));
    }

    IEnumerator AppluNoise(float duration = 0.1f, float amplitude = 1.5f, float frecuency = 20)
    {
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = frecuency;
        yield return new WaitForSeconds(duration);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
    }

}
