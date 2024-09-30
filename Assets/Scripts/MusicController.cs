using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioClipSO audioClip;
    private AudioSource music;
    public static event Action<AudioSource> EventMusic;
    private void Awake()
    {
        music = GetComponent<AudioSource>();
    }
    private void ActiveEventMusic()
    {
        EventMusic?.Invoke(music);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ActiveEventMusic();
            audioClip.PlayOneShoot();
        }
    }
}
