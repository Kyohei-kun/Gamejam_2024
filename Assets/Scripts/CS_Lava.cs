using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Lava : MonoBehaviour
{
    bool finish = false;

    private void OnTriggerEnter(Collider other)
    {
        if (finish == false && other.CompareTag("Ring"))
        {
            finish = true;
            QuestSystem.PlayVictoryFX(other.transform.position);
            Destroy(other.gameObject);
        }
    }
}
