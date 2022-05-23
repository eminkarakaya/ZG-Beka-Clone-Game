using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Builds : MonoBehaviour
{
    public GameObject canvas;
    public bool isSelected;

    void Update()
    { 
        if(isSelected)
            canvas.SetActive(true);
        else
            canvas.SetActive(false);
    }
}
