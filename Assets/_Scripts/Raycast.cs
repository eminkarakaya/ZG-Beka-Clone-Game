using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] protected LayerMask layerMask;
    public RaycastHit hit;

    protected void CastRay()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f,.5f,0));
        
        if(Physics.Raycast(ray,out hit,Mathf.Infinity , layerMask))
        {
            Debug.DrawRay(transform.position, - transform.position + hit.point,Color.red);        
        }
    }
    protected virtual void Update()
    {
        CastRay();
    }
}
