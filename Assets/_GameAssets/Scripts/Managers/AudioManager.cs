using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource note, brick;
    
    public static AudioManager Instance;
    private void Awake()
    {
        Instance = this;
    }
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
