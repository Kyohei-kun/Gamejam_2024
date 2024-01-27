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
        audioSource.Play();
    }

    public void OnLand()
    {
        audioSource.clip = LandingAudioClip;
        audioSource.Play();
    }
}
