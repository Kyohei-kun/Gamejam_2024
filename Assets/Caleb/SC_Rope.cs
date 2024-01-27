using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class SC_Rope : MonoBehaviour
{
    [SerializeField]
    GameObject ropePart;
    [SerializeField]
    float ropePartSize = 1;
    [SerializeField]
    int length = 1;

    List<GameObject> listRopeParts = new List<GameObject>();
    

    [Button]
    private void GenerateRope()
    {
        for(int i=0; i < listRopeParts.Count; i++)
        {
            GameObject.DestroyImmediate(listRopeParts[i]);
        }

        listRopeParts.Clear();
        GameObject pastPart = null;

        for (int i = 0; i < length; i++)
        {
            GameObject newRopePart;
            if (i == 0)
            {
                newRopePart = GameObject.Instantiate(ropePart, transform.position + (-transform.up * (ropePartSize * i)), Quaternion.identity, transform);
            }
            else
            {
                newRopePart = GameObject.Instantiate(ropePart, transform.position + (-transform.up * (ropePartSize * i)), Quaternion.identity, pastPart.transform);
            }

            listRopeParts.Add(newRopePart);
            HingeJoint newJoint = newRopePart.AddComponent<HingeJoint>();

            if(i != 0)
            {
                newJoint.connectedBody = pastPart.GetComponent<Rigidbody>();
            }

            pastPart = newRopePart;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
