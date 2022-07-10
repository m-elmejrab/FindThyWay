using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioClip footsteps;
    [SerializeField] AudioClip orbCreation;

    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip lossSound;

    [SerializeField] AudioClip mainMenuMusic;
    [SerializeField] AudioClip gameplayMusic;

    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayClickSound()
    {
        source.PlayOneShot(clickSound);
    }

    public void PlayMainMenuMusic()
    {
        source.clip = mainMenuMusic;
        source.Play();
    }

    public void PlayLevelMusic()
    {
        source.clip = gameplayMusic;
        source.Play();
    }

    public void PlayFootsteps()
    {
        source.PlayOneShot(footsteps, 0.2f);
    }

    public void PlayOrbCreationSound()
    {
        source.PlayOneShot(orbCreation);
    }

    public void PauseResumeMusic(bool shouldPlay)
    {
        if(shouldPlay)
            source.UnPause();
        else
            source.Pause();
            
    }

    public void PlayWinOrLose(bool hasWon)
    {
        source.Stop();
        if(hasWon)
            source.PlayOneShot(winSound);
        else
            source.PlayOneShot(lossSound);
    }

}
