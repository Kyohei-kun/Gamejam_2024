using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PouicAnimationEvents : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    public AudioClip LandingAudioClip;
    public AudioClip[] FootstepAudioClips;


    public void OnFootstep()
    {
        var index = Random.Range(0, FootstepAudioClips.Length);
        audioSource.clip = FootstepAudioClips[index];
        audioSource.pitch = Random.Range(0.6f, 0.9f);
        audioSource.volume = 0.2f;
        audioSource.Play();
    }

    public void OnLand()
    {
        audioSource.volume = 0.4f;
        audioSource.clip = LandingAudioClip;
        audioSource.Play();
    }
}
