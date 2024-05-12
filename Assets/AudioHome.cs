using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHome : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip musichome;

    private void Start()
    {
        musicSource.clip = musichome;
        musicSource.Play();
    }
}
