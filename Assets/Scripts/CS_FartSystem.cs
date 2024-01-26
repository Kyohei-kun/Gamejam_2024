using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CS_FartSystem : MonoBehaviour
{
    float cooldown = 0.5f;
    float currentCooldown = 0f;

    private void OnFart(InputValue value)
    {
        int i = -1;
        foreach (var item in FartMagazin.items)
        {
            i++;
            if(Vector3.Distance(item.transform.position, transform.position) < FartMagazin.distance[i])
            {
                FartMagazin.iFarts[i].FartInteract();
            }
        }
    }
}

public static class FartMagazin
{
    public static List<CS_I_Fart> iFarts = new List<CS_I_Fart>();
    public static List<GameObject> items = new List<GameObject>();
    public static List<float> distance = new List<float>();


    public static void AddAbo(CS_I_Fart fart,GameObject go, float distanceTrigger)
    {
        iFarts.Add(fart);
        items.Add(go);
        distance.Add(distanceTrigger);
    }
}