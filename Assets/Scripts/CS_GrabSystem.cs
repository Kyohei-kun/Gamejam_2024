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

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip_Grab;
    [SerializeField] AudioClip audioClip_UnGrab;

    private void OnGrab(InputValue value)
    {
        if (value.Get<float>() == 1)
        {
            List<Collider> col = Physics.OverlapSphere(transform.position, 5, layerMask).ToList();
            if (col.Count > 0)
            {
                List<Collider> sortedList = col.OrderBy(obj => Vector3.Distance(transform.position, obj.transform.position)).ToList();
                currentGrab = sortedList[0].gameObject;

                currentGrab.transform.parent = socket;
                currentGrab.transform.localPosition = Vector3.zero;
                currentGrab.GetComponent<Rigidbody>().isKinematic = true;
                audioSource.clip = audioClip_Grab;
                audioSource.PlayOneShot(audioClip_Grab);
                CS_I_Item i_Item = currentGrab.GetComponent<CS_I_Item>();//.OnGrab();
                if (i_Item != null)
                    i_Item.OnGrab();

            }
        }
        else if (value.Get<float>() < 0.9)
        {
            if (currentGrab != null)
            {
                currentGrab.GetComponent<Rigidbody>().isKinematic = false;
                currentGrab.transform.parent = null;
                audioSource.PlayOneShot(audioClip_UnGrab);
                CS_I_Item i_Item = currentGrab.GetComponent<CS_I_Item>();//.OnGrab();
                if (i_Item != null)
                    i_Item.OnUnGrab();
            }
        }
    }
}
