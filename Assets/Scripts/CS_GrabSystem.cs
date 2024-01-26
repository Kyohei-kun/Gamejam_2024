using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CS_GrabSystem : MonoBehaviour
{
    [SerializeField] Transform socket;
    [SerializeField] LayerMask layerMask;
    GameObject currentGrab;

    private void OnGrab(InputValue value)
    {
        if(value.Get<float>()== 1)
        {
            List<Collider> col = Physics.OverlapSphere(transform.position, 5, layerMask).ToList();
            if(col.Count>0)
            {
                currentGrab = col[0].gameObject;
                currentGrab.transform.parent = socket;
                currentGrab.transform.localPosition = Vector3.zero;
                currentGrab.GetComponent<Rigidbody>().isKinematic = true;
                currentGrab.GetComponent<CS_I_Item>().OnGrab();
            }
        }
        else if(value.Get<float>()== 0)
        {
            if(currentGrab != null)
            {
                currentGrab.GetComponent<Rigidbody>().isKinematic = false;
                currentGrab.transform.parent = null;
                currentGrab.GetComponent<CS_I_Item>().OnUnGrab();
            }
        }
    }
}
