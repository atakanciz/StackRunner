using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField] private AudioSource note, brick;
    
    public void PlayNote(float pitch)
    {
        note.pitch = pitch;
        note.Play();
    }

    public void PlayBrick()
    {
        brick.Play();
    }
}
