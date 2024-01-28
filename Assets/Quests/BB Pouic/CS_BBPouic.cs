using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_BBPouic : MonoBehaviour
{
    [SerializeField] GameObject fxPleur;
    [SerializeField] GameObject fx;

    [SerializeField] AudioSource audioSource;

    public void BallonDrop()
    {
        Destroy(fxPleur);
        fx.SetActive(true);
        QuestSystem.PlayVictoryFX(transform.position);
        CS_QuestUISystem.Validate(6);
        Destroy(audioSource);
    }
}
