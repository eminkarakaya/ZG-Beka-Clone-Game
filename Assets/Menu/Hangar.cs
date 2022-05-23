using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangar : MonoBehaviour
{
    public int level;
    class Ucak 
    {
        string ucakTipi;
        List<Gun> guns;
    }
    class Birlikler
    {
        List<PlayerOnGround> playerOnGrounds;
        List<string> weaponType;
    }
}
