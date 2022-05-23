using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UcakSelectedGun : MonoBehaviour
{
    Slots slots;
    public List<GunData> allGuns;
    public List<GameObject> prefab;
    void Awake()
    {
        slots = GameObject.FindObjectOfType<Slots>();
        
    }
    public void CreateGunInfos()
    {
        for (int i = 0; i < allGuns.Count; i++)
        {
            var silahbtn = prefab[i].GetComponent<GunInfo>();
            silahbtn.level.text =  allGuns[i].level.ToString();
            silahbtn.sprite.sprite =  allGuns[i].weaponSprite;
            silahbtn.text.text =  allGuns[i].name;
            silahbtn.selectedGunData = allGuns[i];
        }
    }
}
