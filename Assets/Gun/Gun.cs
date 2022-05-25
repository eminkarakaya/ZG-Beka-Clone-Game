using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Gun : Raycast , IGun
{
    
    public Material isinmaMat;
    public Material eskiIsinmaMat;
    public bool isMaxValue;
    public int isinmaSayisi = 50;
    float memidolumSuresi = 0.05f;
    float memidolumSuresiTemp;
    public Slider slider;
    Slots slots;
    public int slot;
    Image gunImage;
    [SerializeField] public GunData gunData;
    bool isClicked;
    public float cooldown;
    float cooldownTemp;
    bool machinegunFireReady;
    public GameObject gun;
    float randomX = -.5f;
    float randomZ = .5f;
    Queue<GameObject> bullets = new Queue<GameObject>();

    void Start()
    {
        memidolumSuresiTemp = memidolumSuresi;
        slider = GetComponentInChildren<Slider>();
        slots = FindObjectOfType<Slots>();
        slider.maxValue = isinmaSayisi;
        slider.value = 0;
        GetSlot(slot);
        if(gunData == null)
        {
            Destroy(gameObject);
            return;
        }

        cooldown = gunData.attackRate;
        gunImage = GetComponent<Image>();
        gunImage.sprite = gunData.weaponSprite;
        gunData.attackRate = cooldown;
        cooldownTemp = cooldown;
    }
    public void GetSlot(int index)
    {
        if(slots.gunDatas.Count >= index)
        {
            gunData = slots.gunDatas[index-1];
        }
    }
    protected override void Update()
    {
        base.Update();
        if(!isClicked)
        {
            memidolumSuresi -= Time.deltaTime;
            if(memidolumSuresi < 0)
            {
                slider.value --;
                memidolumSuresi = memidolumSuresiTemp;
            }
        }
        Cooldown(ref cooldown, ref cooldownTemp);
        
        if(slider.value == slider.maxValue)
        {
            slider.transform.GetChild(1).GetComponent<Image>().color = Color.red;
            isMaxValue = true;
            StartCoroutine(Isinma());
        }
        if(isClicked && !isMaxValue)
        {
            Fire(gunData.bulletType , ref cooldown, ref cooldownTemp);
        }
        
    }
    public IEnumerator Isinma()
    {
        yield return new WaitForSeconds(2);
        isMaxValue = false;
        Debug.Log(slider.transform.GetChild(1).name);
        slider.transform.GetChild(1).GetComponent<Image>().color = Color.white;
    }
    public void ClickTrue()
    {
        isClicked = true;
    }
    public void ClickFalse()
    {
        isClicked = false;
    }
    
    public void Cooldown(ref float coolDown ,ref float cooldownTemp)
    {
        coolDown -= Time.deltaTime;
        if(coolDown < 0 )
        {
            machinegunFireReady = true;
        }
        else
        {
            machinegunFireReady = false;
        }
    }
    
    public void Fire(int poolIndex ,ref float coolDown ,ref float cooldownTemp)
    {
        if(machinegunFireReady)
        {
            float _randomX = Random.Range(randomX,randomZ);
            float _randomZ = Random.Range(randomX,randomZ);
            var bullet = ObjectPool.Instance.GetPooledObject(poolIndex , gun.transform.position);
            bullets.Enqueue(bullet);
            var dirPoint = hit.point;
            var dir = (dirPoint - gun.transform.position + new Vector3(_randomX,0,_randomZ)).normalized; 
            bullet.GetComponent<Bullet>().dir = dir;
            dirPoint = hit.point;
            coolDown = cooldownTemp;
            slider.value ++;
            AudioSource.PlayClipAtPoint(gunData.fireSound,gun.transform.position);
        }   
    }
}
