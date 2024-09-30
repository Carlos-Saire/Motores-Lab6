using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource Music;
    private void Awake()
    {
        Music = GetComponent<AudioSource>();
    }
    private void ActiveMusic(AudioSource audioSource)
    {
        if (Music.clip != audioSource.clip)
        {
            Music.clip = audioSource.clip;
            Music.Play();
        }
    }
    private void OnEnable()
    {
        MusicController.EventMusic+=ActiveMusic;
    }
    private void OnDisable()
    {
        MusicController.EventMusic -= ActiveMusic;
    }
}
