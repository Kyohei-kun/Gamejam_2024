using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Enceinte : MonoBehaviour
{
    [SerializeField]
    GameObject pivotJack;
    [SerializeField]
    AudioSource playerAudio;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    SC_Jack jackPlugged;
    [SerializeField]
    AudioClip pcMusic;

    public SC_Jack JackPlugged { get { return jackPlugged; } }
    
    public void PcPlay()
    {
        GetComponent<AudioReverbFilter>().enabled = false;
        audioSource.clip = pcMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
    
    public void MicPlay()
    {
        audioSource.loop = false;
        GetComponent<AudioReverbFilter>().enabled = true;
        audioSource.PlayOneShot(playerAudio.clip);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<SC_Jack>() && jackPlugged == null)
        {
            jackPlugged = other.GetComponent<SC_Jack>();
            other.attachedRigidbody.useGravity = false;
            other.transform.position = pivotJack.transform.position;

            if(jackPlugged.IsPc)
                PcPlay();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<SC_Jack>() == jackPlugged)
        {
            jackPlugged = null;

            audioSource.Stop();
        }
    }
}
