using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------- Audio Source -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("----------- Audio Clip -----------")]
    public AudioClip background;
    public AudioClip death;

    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void Death()
    {
        musicSource.clip = death;
        musicSource.Play();
    }
}
