using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;
using System;


public class PlayerOnGround : MonoBehaviour
{
    public AudioClip bombPlantedSound;
    public bool textbool;
    public Transform bombaPatlamaTransform;
    public GameObject towerText;
    public GameObject plantSlider;
    public static event Action<int> OnMetalCollected;
    public static event Action<int> OnMalzemeCollected;
    public GameObject effect;
    public float plantTime;
    public float plantTimeTemp;
    public float bombadanKacmaSuresi;
    public float bombadanKacmaSuresiTemp;
    Animator animator;
    EnemiesInRange enemiesInRange;
    public List<Enemy> enemies;
    public float attackRate;
    public float attackRateTemp;
    public int damage;
    public Tasks tasks;
    List<Transform> targets;
    NavMeshAgent agent;
    private float _speed;
    public float speed
    {
        get => _speed;
        set
        {
            _speed = value;
            agent.speed = _speed;
        }
    }
    void Start()
    {
        plantSlider.GetComponent<Slider>().maxValue = plantTime;
        bombadanKacmaSuresi += plantTime;
        bombadanKacmaSuresiTemp = bombadanKacmaSuresi;
        plantTimeTemp = plantTime;
        animator = GetComponent<Animator>();
        enemiesInRange = GetComponentInChildren<EnemiesInRange>();
        enemies = enemiesInRange.enemies;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }
    void Update()
    {
        CheckFire();

        if(tasks == Tasks.move)
        {
            speed = 3;
            animator.SetBool("Attack",false);
        }else if(tasks == Tasks.killZombies)
        {
            speed = 0;
            animator.SetBool("Attack",true);
        }else if(tasks == Tasks.plantBomb)
        {
            animator.SetBool("Attack",false);
            speed = 0;
        }
        else if(tasks == Tasks.destroyTower)
        {
            animator.SetBool("Attack",true);
            speed = 0;
        }
    }
    
    public void Move(Transform target)
    {
        tasks = Tasks.move;    
        agent.destination = target.position;

        
        var distance = Vector3.Distance(transform.position,target.transform.position);
        if(distance < 1)
        {
            GameManager.Instance.index++;
        }
    }
    public void CheckFire()
    {
        if(enemies.Count != 0)
        {
            GameManager.Instance.index = 0;
        }
        else
        {
            GameManager.Instance.index = GameManager.Instance.tempIndex;
        }
    }
    public void Fire()
    {

        if(enemies.Count == 0)
        {   
            tasks = Tasks.move;
            return;
        }
        tasks = Tasks.killZombies;
        if(enemies[0]!= null)
        {
            transform.LookAt(enemies[0].gameObject.transform);
            attackRateTemp -= Time.deltaTime;
            if(attackRateTemp < 0)
            {
                enemies[0].gameObject.GetComponent<Health>().Hp -= damage;
                attackRateTemp = attackRate;
            }
        }
    }
    public void FireTower(GameObject tower)
    {
        if(tower == null)
        {
            GameManager.Instance.index++;
            return;
        }
        if(!textbool)
            StartCoroutine(TowerText());
        tasks = Tasks.destroyTower;
        transform.LookAt(tower.transform);
        attackRateTemp -= Time.deltaTime;
        if(attackRateTemp < 0)
        {
            tower.GetComponent<Health>().Hp -= damage;
            attackRateTemp = attackRate;
        }
        if(tower.GetComponent<Health>().Hp <= 0)
        {
            GameManager.Instance.index++;
        }
    }
    IEnumerator TowerText()
    {
        towerText.SetActive(true);
        yield return new WaitForSeconds(2);
        towerText.SetActive(false);
        textbool = true;
    }
    public IEnumerator BombaPatlama()
    {
        var bombaPatlamaTransformm = Instantiate(bombaPatlamaTransform,transform.position,Quaternion.identity);
        bombaPatlamaTransformm.parent = null;
        PlayerPrefs.SetInt("Metal", PlayerPrefs.GetInt("Metal") + GameManager.Instance.kazanilacakMetal);
        PlayerPrefs.SetInt("Malzeme",PlayerPrefs.GetInt("Malzeme") +GameManager.Instance.kazanilacakMalzeme);
        yield return new WaitForSeconds(bombadanKacmaSuresi);
        Instantiate(effect,bombaPatlamaTransformm.position,Quaternion.identity);
        plantTime = plantTimeTemp;
        bombadanKacmaSuresi = bombadanKacmaSuresiTemp;
        plantSlider.GetComponent<Slider>().value = 0;
        // OnMalzemeCollected.Invoke(GameManager.Instance.kazanilacakMalzeme);
        // OnMetalCollected.Invoke(GameManager.Instance.kazanilacakMetal);
    }

    public void PlantBomb()
    {
        
        plantSlider.SetActive(true);
        plantSlider.GetComponent<Slider>().value += Time.deltaTime;
        tasks = Tasks.plantBomb;
        plantTime -= Time.deltaTime;
        bombadanKacmaSuresi -= Time.deltaTime;
        if(plantTime <= 0)
        {
            AudioSource.PlayClipAtPoint(bombPlantedSound,transform.position);
            plantTime = plantTimeTemp;
            plantSlider.SetActive(false);
            GameManager.Instance.index ++;
            StartCoroutine(BombaPatlama());
        }
    }
    
    

}

