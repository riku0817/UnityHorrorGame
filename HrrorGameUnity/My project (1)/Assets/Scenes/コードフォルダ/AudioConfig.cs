using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioConfig : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] Slider volumeSlider;
    private void Start()
    {
        volumeSlider.onValueChanged.AddListener((value)=>
        {
            value = Mathf.Clamp01(value);
            float decibel = 20f * Mathf.Log10(value);
            decibel = Mathf.Clamp(decibel,-80f,0f);
            audioMixer.SetFloat("Master",decibel);
        });
    }
}
