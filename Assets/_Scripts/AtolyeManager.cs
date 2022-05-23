using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    

public class TumSilahlariSirala :  MonoBehaviour{
    
    public List<GunData> allGuns;
    public List<GameObject> prefab;
    public GameObject parentObject;
    public void CreateGunInfos()
    {
        for (int i = 0; i < allGuns.Count; i++)
        {
            prefab[i].SetActive(true);
            var silahbtn = prefab[i].GetComponent<GunInfo>();
            silahbtn.level.text =  allGuns[i].level.ToString();
            silahbtn.sprite.sprite =  allGuns[i].weaponSprite;
            silahbtn.text.text =  allGuns[i].name;
            silahbtn.selectedGunData = allGuns[i];
        }
        
    }
    void Awake()
    {
        //Debug.Log("atolye");
        CreateGunInfos();
    }
    void Update()
    {
        
    }

    
}