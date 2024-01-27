using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class CS_Trompette : MonoBehaviour, CS_I_Item, CS_I_Fart
{
    bool Grab = false;
    bool NoteIsPlay = false;

    [SerializeField] VisualEffect note;

    private void Start()
    {
        FartMagazin.AddAbo(this, gameObject, 2);
    }

    public void FartInteract()
    {
        if (Grab && NoteIsPlay == false)
        {
            note.Play();
            NoteIsPlay = true;
        }
    }

    public void OnGrab()
    {
        Grab = true;
    }

    public void OnUnGrab()
    {
        note.Stop();
        NoteIsPlay= false;
        Grab = false;
    }
}
