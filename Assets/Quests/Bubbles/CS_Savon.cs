using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Savon : MonoBehaviour, CS_I_Fart
{
    [SerializeField] CS_BubuleQuest bubuleQuest;

    private void Start()
    {
        FartMagazin.AddAbo(this, gameObject, 2);
    }

    public void FartInteract()
    {
        bubuleQuest.Check();
    }
}
