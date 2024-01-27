using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;


public class CS_FartSystem : MonoBehaviour
{
    [SerializeField] List<AudioClip> fartClips;
    [SerializeField] Animator animator;

    [SerializeField] float cooldown = 0.5f;
    [SerializeField] float currentCooldown = 0f;

    private void Update()
    {
        if(currentCooldown != 0)
        {
            currentCooldown -= Time.deltaTime;
            currentCooldown = Mathf.Clamp(currentCooldown, 0, cooldown);
        }
    }

    private void OnFart(InputValue value)
    {
        if (currentCooldown == 0)
        {
            animator.SetFloat("NumFart", Random.Range(0,2));
            animator.SetTrigger("Fart");
            currentCooldown = cooldown;
            AudioSource.PlayClipAtPoint(fartClips[Random.Range(0, fartClips.Count - 1)], transform.position);
            CheckItems();
        }
    }

    private void CheckItems()
    {
        FartMagazin.CleanList();
        int i = -1;
        foreach (var item in FartMagazin.items)
        {
            i++;
            if (Vector3.Distance(item.transform.position, transform.position) < FartMagazin.distance[i])
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


    public static void AddAbo(CS_I_Fart fart, GameObject go, float distanceTrigger)
    {
        iFarts.Add(fart);
        items.Add(go);
        distance.Add(distanceTrigger);
    }

    public static void CleanList()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null)
            {
                items.RemoveAt(i);
                iFarts.RemoveAt(i);
                distance.RemoveAt(i);
            }
        }
    }
}