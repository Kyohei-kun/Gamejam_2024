using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_DebugItem : MonoBehaviour, CS_I_Fart
{
    public void FartInteract()
    {
        Debug.Log(gameObject.name);
    }

    void Start()
    {
        FartMagazin.AddAbo(this, gameObject, 5);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
