using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSFX;
    [SerializeField] private AudioSource audioMusic;
    [SerializeField] private AudioSource audioSound;
    [SerializeField] private AudioClip battleClip;

    public void PlayBattleMusic()
    {
        audioSound.clip = battleClip;
        audioSound.Play();
    }

    public void PlaySFXOnClick(AudioClip music)
    {
        audioSFX.clip = music;
        audioSFX.Play();
    }

    public void PlaySoundOnClick(AudioClip music)
    {
        audioSound.clip = music;
        audioSound.Play();
    }

    public void PlayMusicOnClick(AudioClip music)
    {
        audioMusic.clip = music;
        audioMusic.Play();
    }

    public void StopSFXOnClick()
    {
        audioSFX.Stop();
    }

    public void StopSoundOnClick()
    {
        audioSound.Stop();
    }

    public void StopMusicOnClick()
    {
        audioMusic.Stop();
    }
}
