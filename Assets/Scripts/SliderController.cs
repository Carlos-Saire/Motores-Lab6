using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private AudioMixerSO audioMixer;
    Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    private void Start()
    {
        slider.value=audioMixer.GetCurrentVolumeValue();
    }
}
