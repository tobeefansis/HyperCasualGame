﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXClient : MonoBehaviour 
{
    [SerializeField] AudioClip Clip;
    public void PlayMusic()
    {
        SFXServer.Main.PlayMusic(Clip);
    }
    public void PlayMusic(AudioClip Clip)
    {
        SFXServer.Main.PlayMusic(Clip);
    }
    public void PlayAudio()
    {
        SFXServer.Main.PlayAudio(Clip);
    }
    public void PlayAudio(AudioClip Clip)
    {
        SFXServer.Main.PlayAudio(Clip);
    }
}
