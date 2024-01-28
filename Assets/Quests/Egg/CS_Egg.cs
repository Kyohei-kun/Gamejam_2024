using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CS_Egg : MonoBehaviour, CS_I_Item
{
    [SerializeField] GameObject pref_BebePouic;

    public void OnGrab(){}

    public void OnUnGrab()
    {
        List<Collider> col = Physics.OverlapSphere(transform.position, 2).ToList();
        foreach (Collider c in col)
        {
            CS_Pouicette pouicette = c.GetComponent<CS_Pouicette>();
            if (pouicette != null && pouicette.Finish)
            {
                QuestSystem.PlayVictoryFX(transform.position);
                CS_QuestUISystem.Validate(5);
                GameObject bb = Instantiate(pref_BebePouic);
                bb.transform.position = gameObject.transform.position + Vector3.up * -1f;
                bb.transform.rotation = Quaternion.LookRotation((Vector3.ProjectOnPlane((GameObject.FindGameObjectWithTag("Player").transform.position - transform.position), Vector3.up)));
                Destroy(gameObject);
            }
        }
    }
}
