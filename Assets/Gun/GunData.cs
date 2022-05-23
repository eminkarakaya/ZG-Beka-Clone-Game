using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Guns")]
public class GunData : ScriptableObject , IGun
{
    public string gunName;
    public int bulletType;
    public Sprite weaponSprite;
    public float damage = 32;
    public float attackRate = .08f;
    public float reloadTime = 5.26f;
    public int level =1;
    public float isinma = 3f;

}
