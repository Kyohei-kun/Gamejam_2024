using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Port : MonoBehaviour
{
    [SerializeField]
    SC_Bateau bateau;

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.GetComponent<SC_Bateau>())
        {
            if(!bateau.IsGrab)
            {
                bateau.ParkBoat();
            }
        }
    }
}
