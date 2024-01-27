using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Jack : MonoBehaviour
{
    [SerializeField]
    private bool isPc  = false;
    [SerializeField]
    private bool isMic = false;

    public bool IsPc { get { return isPc; } }
    public bool IsMic { get { return isMic; } }
}
