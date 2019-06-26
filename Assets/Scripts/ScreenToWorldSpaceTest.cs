using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToWorldSpaceTest : MonoBehaviour
{
    void Awake()
    {

        var frustumHeight = 2.0f * 1 * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);
        Debug.Log(frustumHeight);


    }
}
