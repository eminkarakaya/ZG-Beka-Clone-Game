using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesInRange : MonoBehaviour
{
    public GameObject saldiriText;
    public List<Enemy> enemies;

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            if(enemies.Count == 0)
            {
                enemies.Add(enemy);
                saldiriText.SetActive(true);
                StartCoroutine(saldiritxt());
            }
            else
            {
                enemies.Add(enemy);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            enemies.Remove(enemy);
        }
    }
    public IEnumerator saldiritxt()
    {
        yield return new WaitForSeconds(2);
        saldiriText.SetActive(false);
    }
    void Update()
    {
        

        for (int i = 0; i < enemies.Count; i++)
        {
            if(enemies[i] == null)
            {
                enemies.Remove(enemies[i]);
                continue;
            }
                
            if(enemies[i].GetComponent<Health>().Hp <= 0)
            {
                enemies.Remove(enemies[i]);
            }
        }
    }
}
