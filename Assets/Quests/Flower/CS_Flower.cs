using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CS_Flower : MonoBehaviour, CS_I_Fart
{
    [SerializeField] GameObject normalModel;
    [SerializeField] GameObject fannedModel;
    [SerializeField] VisualEffect petals;

    private CS_FlowerQuest flowerQuest;

    bool state = false;

    private void Start()
    {
        FartMagazin.AddAbo(this, gameObject, 1);
    }

    public void SetFlowerQuest(CS_FlowerQuest quest)
    {
        flowerQuest = quest;
    }

    public void FartInteract()
    {
        if (state != true)
        {
            state = true;
            flowerQuest.OnFannedFlower(transform.position);
            normalModel.SetActive(false);
            fannedModel.SetActive(true);
            petals.Play();
        }
    }
}
