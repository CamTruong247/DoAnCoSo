using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource walkSource;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioMixer audioMixer;

    public AudioClip musichome;
    public AudioClip damagehealth;
    public AudioClip attack;
    public AudioClip attackenemy;
    public AudioClip skill;
    public AudioClip walk;

    private void Start()
    {
        if (musicSource != null)
        {
            musicSource.clip = musichome;
            musicSource.Play(); 
        }
        if (musicSlider != null && sfxSlider != null)
        {
            if (PlayerPrefs.HasKey("Music") || PlayerPrefs.HasKey("SFX"))
            {
                LoadVolume();
            } 
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        PlayerPrefs.SetFloat("Music", volume);
        audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        PlayerPrefs.SetFloat("SFX", volume);
        audioMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Music");
        sfxSlider.value = PlayerPrefs.GetFloat("SFX");
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void StopSFX(AudioClip clip)
    {
        SFXSource.Stop();
    }
    public void PlayWalkSFX()
    {
        if (!walkSource.isPlaying)
        {
            walkSource.clip = walk;
            walkSource.Play();
        }
    }

    public void StopWalkSFX()
    {
        if (walkSource.isPlaying)
        {
            walkSource.Stop();
        }
    }

}
