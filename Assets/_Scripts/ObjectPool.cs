using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ObjectPool : Singleton<ObjectPool>
{
    [Serializable] 
    struct Pool
    {
        public Queue<GameObject> pooledObject;
        public GameObject objectPrefab;
        public int poolSize;
    }
    [SerializeField] private Pool[] pools = null;
    void Awake()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i].pooledObject = new Queue<GameObject>();
            for (int j = 0; j < pools[i].poolSize; j++)
            {
                GameObject obj = Instantiate(pools[i].objectPrefab);
                obj.SetActive(false);
                pools[i].pooledObject.Enqueue(obj);
            }
        }
    }
    public GameObject GetPooledObject(int objectType,Vector3 position)
    {
        if(objectType >= pools.Length)
        {
            return null;
        }
        GameObject obj = pools[objectType].pooledObject.Dequeue();

        obj.transform.position = position;
        obj.SetActive(true);

        pools[objectType].pooledObject.Enqueue(obj);

        return obj;
    }
    public void SetPooledObject(GameObject pooledObject , int objectType)
    {
        if(objectType >= pools.Length) return;
        pools[objectType].pooledObject.Enqueue(pooledObject);
        pooledObject.SetActive(false);
    }

}
