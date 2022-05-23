using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GunInfo : MonoBehaviour{

    Slots slots;
    public int index;
    public GunData selectedGunData;
    public Text text;
    public Image sprite;
    public Text level;
    void Awake()
    {
        slots = GameObject.FindObjectOfType<Slots>();
    }
    public void GetSelectedGunData()
    {
        if(slots.selectedGundata!=null)
        {
            selectedGunData = slots.selectedGundata;
            text.text = selectedGunData.gunName;
            sprite.sprite = selectedGunData.weaponSprite;
            level.text = selectedGunData.level.ToString();
            SetSlot(selectedGunData,index);
        }
    }
    public void SetSlot(GunData selectedGunData , int index)
    {
        slots.gunDatas[index-1] = selectedGunData;
    }
}
