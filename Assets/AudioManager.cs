using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip musichome;
    public AudioClip damagehealth;

    private void Start()
    {
        if (musicSource != null)
        {
            musicSource.clip = musichome;
            musicSource.Play(); 
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
