using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CS_QuestSystem : MonoBehaviour
{
    [SerializeField] VisualEffect effect;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    private void Start()
    {
        QuestSystem.Init();
    }

    public void PlayVictoryFX(Vector3 position)
    {
        effect.transform.position = position;
        effect.Play();
        audioSource.clip = audioClip;
        audioSource.PlayOneShot(audioSource.clip);
    }
}

public static class QuestSystem
{
    static CS_QuestSystem currentQuestSystem;
    static public void Init()
    {
        currentQuestSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<CS_QuestSystem>();
    }

    public static void PlayVictoryFX(Vector3 position)
    {
        currentQuestSystem.PlayVictoryFX(position);
    }
}
