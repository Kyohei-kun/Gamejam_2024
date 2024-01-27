using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CS_QuestSystem : MonoBehaviour
{
    [SerializeField] VisualEffect effect;

    private void Start()
    {
        QuestSystem.Init();
    }

    public void PlayVictoryFX(Vector3 position)
    {
        effect.transform.position = position;
        effect.Play();
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
