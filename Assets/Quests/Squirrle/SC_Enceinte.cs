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

    public bool pcPlaying = false;

    public SC_Jack JackPlugged { get { return jackPlugged; } }
    public GameObject PivotJack { get { return pivotJack; } }

    private void Start()
    {
        //jackPlugged.gameObject.GetComponent<Rigidbody>().useGravity = false;
        //jackPlugged.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        //jackPlugged.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //jackPlugged.gameObject.GetComponent<MeshCollider>().isTrigger = true;
        //jackPlugged.gameObject.transform.SetPositionAndRotation(pivotJack.transform.position, pivotJack.transform.rotation);

        //PcPlay();
    }

    public void PcPlay()
    {
        audioSource.GetComponent<AudioReverbFilter>().enabled = false;
        audioSource.clip = pcMusic;
        audioSource.loop = true;
        audioSource.Play();
        pcPlaying = true;
    }
    
    public void MicPlay()
    {
        audioSource.loop = false;
        pcPlaying = false;
        audioSource.GetComponent<AudioReverbFilter>().enabled = true;
        audioSource.clip = playerAudio.clip;
        audioSource.PlayDelayed(0.2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<SC_Jack>())
        {
            if(jackPlugged == null && !other.gameObject.GetComponent<SC_Jack>().IsGrab)
            {
                jackPlugged = other.GetComponent<SC_Jack>();
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                other.gameObject.GetComponent<MeshCollider>().isTrigger = true;
                other.gameObject.transform.SetPositionAndRotation(pivotJack.transform.position, pivotJack.transform.rotation);

                if (jackPlugged.IsPc)
                    PcPlay();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.GetComponent<SC_Jack>() == jackPlugged)
        {
            jackPlugged = null;

            pcPlaying = false;
            audioSource.Stop();
        }
    }
}
