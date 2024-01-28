using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_QuestUISystem : MonoBehaviour
{
    static int lastValidate = -1;
    [SerializeField] List<GameObject> checkBox;

    private void Update()
    {
        if(lastValidate != -1)
        {
        checkBox[lastValidate].SetActive(true);
        }
    }

    public static void Validate (int index)
    {
        lastValidate = index;
    }
}