using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="playerGunData")]
public class PlayerGunData   : ScriptableObject
{
    public Text gunName;
    public Sprite weaponSprite;
    public int damage;
    public float attackRate;
    public Text level;
}
