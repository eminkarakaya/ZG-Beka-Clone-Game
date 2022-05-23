using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Slots : MonoBehaviour
{       
    public int slotSayisi = 3;
    public GunData selectedGundata;
    public  List<GunData> gunDatas;
    public void Awake()
    {
        if(gunDatas.Count < 3)
        {
            var eklenecek = 3-gunDatas.Count;
            for (int i = 0; i < eklenecek; i++)
            {
                gunDatas.Add(null);
            }
        }   
        Slots[] objs = GameObject.FindObjectsOfType<Slots>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    public void AddSlot(GunData _gunData , int index)
    {
        gunDatas[index] = _gunData;
    }
}   
