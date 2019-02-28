using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnFX : MonoBehaviour
{
    public AudioSource myFX;
    public AudioClip hoverFX;
    public AudioClip clickFX;
    public AudioClip getCoins;

    private float sfxVolume;

    void Start()
    {
        myFX = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            sfxVolume = PlayerPrefs.GetFloat("sfxVolume");
        }
        else
        {
            sfxVolume = 0.75f;
        }
    }

    void Update()
    {
        myFX.volume = sfxVolume;
    }

    public void SetSfxVolume(float vol)
    {
        sfxVolume = vol;
        PlayerPrefs.SetFloat("sfxVolume", vol);
    }

    public void HoverSound()
    {
        myFX.PlayOneShot(hoverFX);
    }

    public void ClickSound()
    {
        myFX.PlayOneShot(clickFX);
    }

    public void GetCoinsSound()
    {
        myFX.PlayOneShot(getCoins);
    }
}
