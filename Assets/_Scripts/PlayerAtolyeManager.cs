using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAtolyeManager : MonoBehaviour
{
    public List<PlayerGunData> allGuns;
    public List<GameObject> prefab;
    public GameObject parentObject;
    public void CreateGunInfos()
    {
        for (int i = 0; i < allGuns.Count; i++)
        {
            prefab[i].SetActive(true);
            
            var silahbtn = prefab[i].GetComponent<PlayerGunData>();
            silahbtn.level.text =  allGuns[i].level.ToString();
            silahbtn.weaponSprite = allGuns[i].weaponSprite;
            silahbtn.gunName.text =  allGuns[i].name;
        }
        
    }
    void Awake()
    {
        //Debug.Log("atolye");
        CreateGunInfos();
    }
}
