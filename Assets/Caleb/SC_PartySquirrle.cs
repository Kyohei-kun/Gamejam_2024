using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SC_PartySquirrle : MonoBehaviour, CS_I_Fart
{
    [SerializeField]
    bool putJack = false;
    [SerializeField]
    bool throwItem = false;
    [SerializeField]
    Animator animator;
    [SerializeField]
    SC_Enceinte enceinte;
    [SerializeField]
    GameObject jackPC;

    bool plugJack = false;
    float timer = 0f;

    private void Start()
    {
        FartMagazin.AddAbo(this, gameObject, 20);
        animator.SetInteger("dance",Random.Range((int)1,(int)6));
    }

    private void Update()
    {
        animator.SetBool("musicOn", enceinte.pcPlaying);

        if(!enceinte.pcPlaying && !plugJack && enceinte.JackPlugged == null)
        {
            timer += Time.deltaTime;

            if(timer > 5f)
            {
                plugJack = true;
                timer = 0f;
                PutBackJack();
            }
        }
    }

    public void FartInteract()
    {
        if (enceinte.JackPlugged == null) { return; }

        if (enceinte.JackPlugged.IsMic)
        {

            if (throwItem)
            {
                animator.SetTrigger("throw");
            }
            else
            {
                animator.SetTrigger("booh");
            }
        }
    }

    private void PutBackJack()
    {
        if(putJack)
            animator.SetTrigger("plugJack");
    }

    public void SetJackPos() 
    { 
        jackPC.transform.SetPositionAndRotation(enceinte.PivotJack.transform.position, enceinte.PivotJack.transform.rotation); 
        plugJack = false; 
    }

}
