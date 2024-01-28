using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_TableauQuest : MonoBehaviour, CS_I_Fart
{
    bool vert;
    bool vertF;
    bool noir;

    int indexCurrentSceau = 0;

    Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        FartMagazin.AddAbo(this, gameObject, 2);
    }

    public void FartInteract()
    {
        switch (indexCurrentSceau)
        {
            case 0:
                break;
            case 1:
                vert = true;
                break;
            case 2:
                vertF = true;
                break;
            case 3:
                noir = true;
                break;
        }

        mat.SetFloat("_Vert", vert? 1:0);
        mat.SetFloat("_VertF", vertF? 1 : 0);
        mat.SetFloat("_Noir", noir ? 1 : 0);

        if(vert && vertF && noir)
        {
            QuestSystem.PlayVictoryFX(transform.position);
            CS_QuestUISystem.Validate(1);
        }
    }

    public void sceauTenu(int index)
    {
        indexCurrentSceau = index;
    }
}
