using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotaEkleme : MonoBehaviour
{
    public int slot;
    public Slots slots;
    void Start()
    {
        slots = GameObject.FindObjectOfType<Slots>();
        // if(slots.gunDatas.Count < slot)
        // {
        //     slots.gunDatas.Add(null);
        // }
        
        SlotInfoSlot(slot);
    }
    public void SlotInfoSlot(int index)
    {
        if(slots.gunDatas[index-1] != null)
        {
            GetComponent<GunInfo>().selectedGunData = slots.gunDatas[index-1] ;
            GetComponent<GunInfo>().text.text = slots.gunDatas[index-1] .gunName;
            GetComponent<GunInfo>().level.text = slots.gunDatas[index-1] .level.ToString();
            GetComponent<GunInfo>().sprite.sprite = slots.gunDatas[index-1] .weaponSprite;
        }
    }
}
