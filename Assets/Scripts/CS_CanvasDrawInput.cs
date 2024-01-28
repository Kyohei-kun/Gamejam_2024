using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CS_CanvasDrawInput : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    public void OnDrawQuest(InputValue value)
    {
        canvas.enabled = value.Get<float>()== 1? true:false;
    }
}
