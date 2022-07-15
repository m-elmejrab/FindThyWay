using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>  // Singleton class managing all sound effects and music
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

    /// <summary>
    /// Plays UI click sound
    /// </summary>
    public void PlayClickSound()
    {
        source.PlayOneShot(clickSound);
    }

    /// <summary>
    /// Plays main menu music
    /// </summary>
    public void PlayMainMenuMusic()
    {
        source.clip = mainMenuMusic;
        source.Play();
    }

    /// <summary>
    /// Plays level music
    /// </summary>
    public void PlayLevelMusic()
    {
        source.clip = gameplayMusic;
        source.Play();
    }

    /// <summary>
    /// Plays footsteps sfx when player is waling
    /// </summary>
    public void PlayFootsteps()
    {
        source.PlayOneShot(footsteps, 0.2f);
    }

    /// <summary>
    /// Plays beacon placement sfx
    /// </summary>
    public void PlayOrbCreationSound()
    {
        source.PlayOneShot(orbCreation);
    }

    /// <summary>
    /// Pause or unpause music with pause menu
    /// </summary>
    public void PauseResumeMusic(bool shouldPlay)
    {
        if (shouldPlay)
            source.UnPause();
        else
            source.Pause();

    }

    /// <summary>
    /// Plays win or loss sfx when level is finished
    /// </summary>
    public void PlayWinOrLose(bool hasWon)
    {
        source.Stop();
        if (hasWon)
            source.PlayOneShot(winSound);
        else
            source.PlayOneShot(lossSound);
    }

}
