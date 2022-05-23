using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text killCountTxt;
    public Slider hpSlider;
    [SerializeField] private int _hp;
    public int Hp
    {
        get => _hp;
        set 
        {
            _hp = value;
            hpSlider.value = _hp;
            if(_hp <= 0)
            {
                if(this.TryGetComponent(out Enemy enemy))
                {
                    GameManager.Instance.killCount++;
                    killCountTxt.text = GameManager.Instance.killCount.ToString();
                }
                Destroy(gameObject);
            }
        }
    }
}
