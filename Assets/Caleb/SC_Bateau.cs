using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Bateau : MonoBehaviour, CS_I_Item, CS_I_Fart
{
    [SerializeField]
    CharacterController playerCC;
    [SerializeField]
    Transform victoryFxSpawn;
    [SerializeField]
    GameObject passenger;

    private bool isGrab = false;

    public bool IsGrab { get { return isGrab; } }

    public void OnGrab()
    {
        playerCC.enabled = false;
        isGrab = true;
    }

    public void OnUnGrab()
    {
        playerCC.enabled = true;
        isGrab = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Start()
    {
        FartMagazin.AddAbo(this, gameObject, 2);
    }

    public void FartInteract()
    {
        if(isGrab) 
        {
            StopAllCoroutines();
            StartCoroutine(Move());
        }

    }

    public void ParkBoat()
    {
        passenger.GetComponent<Animator>().SetTrigger("happy");
        QuestSystem.PlayVictoryFX(victoryFxSpawn.position);
    }

    IEnumerator Move()
    {
        float distDone = 0;
        Vector3 start = playerCC.gameObject.transform.position;

        while(distDone < 3)
        {
            playerCC.gameObject.transform.position += playerCC.gameObject.transform.forward * 5 * Time.deltaTime;

            distDone = Vector3.Distance(start, playerCC.gameObject.transform.position);

            yield return null;
        }
    }


}
