using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLookAt : MonoBehaviour
{
    [SerializeField] Transform target;
    void LateUpdate()
    {
        transform.LookAt(target);
    }
}
