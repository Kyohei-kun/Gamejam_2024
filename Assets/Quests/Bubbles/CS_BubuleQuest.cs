using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CS_BubuleQuest : MonoBehaviour
{
    bool finish = false;
    bool playerInWater = false;
    [SerializeField] GameObject fx;

    public bool PlayerInWater { get => playerInWater; set => playerInWater = value; }

    public void Check()
    {
        if(playerInWater && finish == false)
        {
            finish = true;
            fx.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + Vector3.up * 1f;
            fx.gameObject.SetActive(true);
            QuestSystem.PlayVictoryFX(transform.position);
            CS_QuestUISystem.Validate(7);
        }
    }
}
