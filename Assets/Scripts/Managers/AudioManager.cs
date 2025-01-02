using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private AudioSource musicSource;
    private AudioSource SFXSource;
    public Slider sliderMusic;
    public Slider sliderSFX;
    public AudioMixer mixer;

    private void Start()
    {
        musicSource = GameObject.FindWithTag("BackgroundMusic").GetComponent<AudioSource>();
        SFXSource = GameObject.FindWithTag("SFX").GetComponent<AudioSource>();

        sliderMusic.value = PlayerPrefs.GetFloat("MusicVolume");
        sliderSFX.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void SetMusicVolume(float volume)
    {
        if (volume > 0.5f)
            mixer.SetFloat("MusicVolume", Mathf.Lerp(-40, 0, volume));
        else if (volume > 0.25f)
            mixer.SetFloat("MusicVolume", Mathf.Lerp(-60, 20, volume));
        else
            mixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 80, volume));

        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        if (volume > 0.5f)
            mixer.SetFloat("SFXVolume", Mathf.Lerp(-40, 0, volume));
        else if (volume > 0.25f)
            mixer.SetFloat("SFXVolume", Mathf.Lerp(-60, 20, volume));
        else
            mixer.SetFloat("SFXVolume", Mathf.Lerp(-80, 80, volume));

        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
}
