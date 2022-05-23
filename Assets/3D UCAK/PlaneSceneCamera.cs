using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSceneCamera : MonoBehaviour
{
    float xMouse =0;
    void Update()
    {
        CameraCtrl();
    }
     private void CameraCtrl()
        {
            float mouseX = Input.GetAxis("Mouse X");
            xMouse += mouseX;
            
            transform.rotation = Quaternion.Euler(0,xMouse,0);
        }
}
