using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_DebugItem : MonoBehaviour, CS_I_Fart
{
    public void FartInteract()
    {
        Debug.Log(gameObject.name); //apel� quand le joueur p�te dans un rayon de 5 Units
    }

    void Start()
    {
        FartMagazin.AddAbo(this, gameObject, 5);   
    }
}
