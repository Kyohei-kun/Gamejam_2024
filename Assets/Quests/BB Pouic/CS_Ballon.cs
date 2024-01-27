using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CS_Ballon : MonoBehaviour, CS_I_Item
{
    public void OnGrab()
    {
    }

    public void OnUnGrab()
    {
        List<Collider> col = Physics.OverlapSphere(transform.position, 3).ToList();
        foreach (Collider c in col)
        {
            CS_BBPouic bb = c.GetComponent<CS_BBPouic>();
            if (bb != null)
            {
                bb.BallonDrop();
            }
        }
    }
}
