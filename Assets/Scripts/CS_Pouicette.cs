using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class CS_Pouicette : MonoBehaviour
{
    bool finish = false;
    [SerializeField] VisualEffect FX_Love;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ring") && finish == false)
        {
            finish = true;
            QuestSystem.PlayVictoryFX(transform.position);
            FX_Love.Play();
        }        
    }
}
