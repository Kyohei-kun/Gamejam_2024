using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class CS_Pouicette : MonoBehaviour
{
    bool finish = true;
    [SerializeField] VisualEffect FX_Love;

    public bool Finish { get => finish; set => finish = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ring") && Finish == false)
        {
            Finish = true;
            QuestSystem.PlayVictoryFX(transform.position);
            FX_Love.Play();
        }        
    }
}
