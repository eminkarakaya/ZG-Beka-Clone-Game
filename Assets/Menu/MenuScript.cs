using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public Material matSelected;
    public Material matNormal;
    private GameObject selectedGameObj;
    void Update()
    {
        if (Input.GetMouseButton(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
            }  
        if(Input.GetKeyDown(KeyCode.Mouse0))
            Select();
    }
    public void SelectedObjectProperties(bool value)
    {
        if(selectedGameObj != null)
        {
            if(selectedGameObj.TryGetComponent(out Builds builds))
            {
                builds.isSelected = value;
            }
        }
    }
    public void Select()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
        // parmağın bir UI öğesinin üzerinde olup olmadığını kontrol edin
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log ("Kullanıcı Arayüzüne Dokundu");
            }
        }  
        if(Physics.Raycast(ray , out hit,100f,LayerMask.GetMask("Build")))
        {
              
            if(selectedGameObj != null)
            {
                MeshRenderer mr_old = selectedGameObj.GetComponent<MeshRenderer>();
                if(mr_old != null)
                {
                    mr_old.material = matNormal;
                }
            }
            SelectedObjectProperties(false);
            selectedGameObj = hit.transform.gameObject;
            SelectedObjectProperties(true);
            MeshRenderer mr = selectedGameObj.GetComponent<MeshRenderer>();
            mr.material = matSelected;
            
        }
        
        else
        {
            SelectedObjectProperties(false);
            if(selectedGameObj != null)
            {
                MeshRenderer mr_old = selectedGameObj.GetComponent<MeshRenderer>();
                if(mr_old != null)
                {
                    mr_old.material = matNormal;
                }
                mr_old = null;
                selectedGameObj = null;
            }
        }
    }
}
