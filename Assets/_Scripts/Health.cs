using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static event System.Action KillEvent;

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
                    KillEvent.Invoke();
                }
                Destroy(gameObject);
            }
        }
    }
    void Start()
    {
        hpSlider.maxValue = _hp;
        hpSlider.value = _hp;
    }
    
}
