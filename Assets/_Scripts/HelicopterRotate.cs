using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HelicopterRotate : MonoBehaviour
{
    [SerializeField] Transform playerOnGround; 
    public float i;
    void Update()
    {
         
        transform.position = playerOnGround.transform.position;
        i+= 0.02f;
        transform.localRotation = Quaternion.Euler(0,i,0); 
    }
}
