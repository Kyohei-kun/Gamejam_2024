using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_WaterTrigger : MonoBehaviour
{
    [SerializeField] CS_BubuleQuest bubuleQuest;

    private void OnTriggerEnter(Collider other)
    {
        bubuleQuest.PlayerInWater = true;
    }
    private void OnTriggerExit(Collider other)
    {
            bubuleQuest.PlayerInWater = false;
    }
}
