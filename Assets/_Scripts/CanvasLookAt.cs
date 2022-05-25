using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLookAt : MonoBehaviour
{
    Transform target;
    void Start()
    {
        target = Camera.main.gameObject.transform;
    }
    void LateUpdate()
    {
        transform.LookAt(target);
    }
}
