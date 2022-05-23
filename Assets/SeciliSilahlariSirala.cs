using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class SeciliSilahlariSirala : MonoBehaviour
{
    public PlayerGunData selectedPlayerGunData;
    public GunData selectedGun;
    public int index;
    Slots slots;
    void Start()
    {
        slots = GameObject.FindObjectOfType<Slots>();
        if(selectedGun == null)
        {
            selectedGun = slots.gunDatas[0];
        }
    }
    public void AddSlot(int index)
    {
        if(selectedGun!= null)
        {
            if(slots.gunDatas[index-1] != null)
                slots.AddSlot(selectedGun , index-1);
        }
    }
    public void Selectt()
    {
        selectedGun = GetComponent<GunInfo>().selectedGunData;
        slots.selectedGundata = selectedGun;
    }
}
