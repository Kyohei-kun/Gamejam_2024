using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Sceau : MonoBehaviour, CS_I_Item
{
    [SerializeField] CS_TableauQuest tableauQuest;
    [SerializeField] int index = 0;
    
    public void OnGrab()
    {
        transform.rotation = Quaternion.EulerRotation(new Vector3(90, 0, 0));
        tableauQuest.sceauTenu(index);
    }

    public void OnUnGrab()
    {
        transform.rotation = Quaternion.EulerRotation(new Vector3(-90, 0, 0));
        tableauQuest.sceauTenu(0);
    }
}
