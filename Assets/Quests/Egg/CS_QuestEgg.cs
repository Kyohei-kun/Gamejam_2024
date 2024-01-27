using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CS_QuestEgg : MonoBehaviour, CS_I_Fart
{
    bool finish = false;
    [SerializeField] GameObject pref_egg;
    bool pouicIn = false;

    private void Start()
    {
        FartMagazin.AddAbo(this, gameObject, 10);
    }

    public void FartInteract()
    {
        if (pouicIn && finish == false)
        {
            fx();
            finish = true;
            GameObject egg = Instantiate(pref_egg);
            egg.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + Vector3.up * -0.5f;
        }
    }

    private async void fx()
    {
        await System.Threading.Tasks.Task.Delay((int)(1000));
        QuestSystem.PlayVictoryFX(gameObject.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        pouicIn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        pouicIn = false;
    }
}
