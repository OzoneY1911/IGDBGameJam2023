using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    internal static AudioManager instance;

    public enum sfxEnum
    {
        menuHover,
        menuClick,
        grannySteps,
        grannyHit
    }

    [Header("Music")]
    public AudioSource musicSource;

    [Header("SFX")]
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioClip[] sfxClips;

    [Header("Volume Sliders")]
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;

    void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this);

        InitVolume();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

	public void PlaySFX(sfxEnum enumClip)
	{
		sfxSource.PlayOneShot(sfxClips[(int)enumClip]);
	}

	public void SetMusicVolume()
    {
        PlayerPrefs.SetFloat("Music Volume", musicVolumeSlider.value);
        musicSource.volume = musicVolumeSlider.value;
    }

    public void SetSFXVolume()
    {
        PlayerPrefs.SetFloat("SFX Volume", sfxVolumeSlider.value);
        sfxSource.volume = sfxVolumeSlider.value;
    }

    void InitVolume()
    {
        if (PlayerPrefs.HasKey("Music Volume"))
        {
            musicVolumeSlider.value = PlayerPrefs.GetFloat("Music Volume");
            musicSource.volume = musicVolumeSlider.value;
        }

        if (PlayerPrefs.HasKey("SFX Volume"))
        {
            sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFX Volume");
            sfxSource.volume = sfxVolumeSlider.value;
        }
    }
}
