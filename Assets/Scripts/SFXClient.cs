using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXClient : MonoBehaviour 
{
    [SerializeField] AudioClip Clip;
    public void PlayMusic()
    {
        SFXServer.Main.PlayMusic(Clip);
    }
    public void PlayAudio()
    {
        SFXServer.Main.PlayAudio(Clip);
    }
}
