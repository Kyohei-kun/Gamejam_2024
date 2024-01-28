using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_FlowerQuest : MonoBehaviour
{
    [SerializeField] List<CS_Flower> flowers;

    int currentFlowerFanned = 0;

    public void OnFannedFlower(Vector3 flowerPos)
    {
        currentFlowerFanned++;
        if(currentFlowerFanned >= flowers.Count)
        {
            QuestSystem.PlayVictoryFX(flowerPos);
            CS_QuestUISystem.Validate(0);
        }
    }

    private void Start()
    {
        foreach (var flower in flowers)
        {
            flower.SetFlowerQuest(this);
        }
    }
}
