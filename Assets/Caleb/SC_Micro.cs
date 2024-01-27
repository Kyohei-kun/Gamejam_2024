using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Micro : MonoBehaviour, CS_I_Fart
{
    [SerializeField]
    SC_Enceinte enceinte;

    public void FartInteract()
    {
        if(enceinte.JackPlugged.IsMic)
        {
            enceinte.MicPlay();
        }
    }

    private void Start()
    {
        FartMagazin.AddAbo(this, gameObject, 5);
    }
}
