using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_DebugItem : MonoBehaviour, CS_I_Fart, CS_I_Item
{
    public void FartInteract()
    {
        Debug.Log("Fart on " + gameObject.name); //apelé quand le joueur pète dans un rayon de 5 Units
        QuestSystem.PlayVictoryFX(gameObject.transform.position);
    }

    public void OnGrab()
    {
        Debug.Log("Grab " + gameObject.name);
    }

    public void OnUnGrab()
    {
        Debug.Log("UnGrab " + gameObject.name);
    }

    void Start()
    {
        FartMagazin.AddAbo(this, gameObject, 5);   
    }
}
