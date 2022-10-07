using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public int currentClip = 0;

    void Start()
    {
        audioSource.clip = audioClips[currentClip];
        audioSource.Play();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            currentClip++;
            if (currentClip >= audioClips.Length)
            {
                currentClip = 0;
            }
            audioSource.clip = audioClips[currentClip];
            audioSource.Play();
        }
        if (currentClip == 5)
        {
            currentClip = 0;
        }
    }
}
