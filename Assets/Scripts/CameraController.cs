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

    public void shake(float duration = 0.3f, float amplitude = 1f, float frecuency = 1f)
    {
        StopAllCoroutines();
        StartCoroutine(AppluNoise(duration, amplitude, frecuency));
    }

    IEnumerator AppluNoise(float duration, float amplitude, float frecuency)
    {
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = frecuency;
        yield return new WaitForSeconds(duration);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
    }

}
