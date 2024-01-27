using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Jack : MonoBehaviour, CS_I_Item
{
    [SerializeField]
    private bool isPc  = false;
    [SerializeField]
    private bool isMic = false;

    private bool isGrab = false;

    public bool IsGrab { get { return isGrab; } }
    public bool IsPc { get { return isPc; } }
    public bool IsMic { get { return isMic; } }

    public void OnGrab() { isGrab = true; }
    public void OnUnGrab() 
    { 
        isGrab = false; 
        GetComponent<Rigidbody>().useGravity = true; 
        gameObject.GetComponent<MeshCollider>().isTrigger = false;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
