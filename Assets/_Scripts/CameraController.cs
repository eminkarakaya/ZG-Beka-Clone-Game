using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{

    public RaycastHit hit;
    GameObject camera;
    public bool isClicked;
    public float moveOffset;
    public float speed;
    public Vector2 sinirX;
    public Vector2 sinirZ;
    Vector3 clickPos;
    public float zoomMiktari;
    void Start()
    {
        camera = transform.GetChild(1).gameObject;
    }
    void Update()
    {
        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            if(zoomMiktari < 10 )
            {
                var zoom = 80f*Time.deltaTime;
                zoomMiktari +=  zoom;
                var vec3 = Vector3.zero;
                vec3.z +=  zoom;
                camera.transform.Translate(vec3 , Space.Self);   
            }
        }
        else if(Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            if(zoomMiktari > -5)
            {
                var zoom = 80f*Time.deltaTime;
                zoomMiktari -=  zoom;
                var vec3 = Vector3.zero;
                vec3.z -=  zoom;
                camera.transform.Translate(vec3 , Space.Self);   
            }
            
        } 
        if(Input.GetMouseButtonDown(0))
        {
            isClicked = true;
            clickPos = Input.mousePosition;
            clickPos.z = clickPos.x;
            clickPos.x =- clickPos.y;
            clickPos.y = 0;
        }
        if(Input.GetMouseButtonUp(0))
        {
            isClicked = false;
        }
        CameraMove();
    }

    public void CameraMove()
    {
        if(isClicked)
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z = mousePosition.x;
            mousePosition.x = -mousePosition.y;
            mousePosition.y = 0;
            
            var pos = Camera.main.ScreenToWorldPoint(clickPos); 
            var direction = mousePosition - clickPos;
            var distance = Vector2.Distance(mousePosition , clickPos);
            if(distance > moveOffset)
            {
                transform.localPosition += direction.normalized*speed*Time.deltaTime;
            }
            if(transform.position.x > sinirX.y)
            {
                Vector3 newpos = new Vector3(sinirX.y,transform.position.y,transform.position.z);
                transform.position = newpos;
            }
            if(transform.position.x < sinirX.x)
            {
                Vector3 newpos = new Vector3(sinirX.x,transform.position.y,transform.position.z);
                transform.position = newpos;
            }
            if(transform.position.z < sinirZ.x)
            {
                Vector3 newpos = new Vector3(transform.position.x,transform.position.y,sinirZ.x);
                transform.position = newpos;
            }
            if(transform.position.z > sinirZ.y)
            {
                Vector3 newpos = new Vector3(transform.position.x,transform.position.y,sinirZ.y);
                transform.position = newpos;
            }
        }
    }
}
