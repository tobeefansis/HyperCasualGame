using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXServer : MonoBehaviour
{
    public static SFXServer Main { get; private set; }
    public AudioSource MusicSource;
    public AudioSource AudioSource;
    void Start()
    {

    }

    private void Awake()
    {
        Main = this;
    }

    void Update()
    {

    }

    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    public void PlayAudio(AudioClip clip)
    {
        AudioSource.clip = clip;
        AudioSource.Play();
    }
}
