using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for storing large amounts of identical prefabs.
/// </summary>
/// <typeparam name="T">Type of prefab to store derived from GameObject.</typeparam>
public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    public T prefab;
    public int amount;

    private Queue<T> pool = new Queue<T>();
    

    public T Get()
    {
        if(pool.Count == 0)
        {
            AddObjects(1);
        }
        return pool.Dequeue();
    }
    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
    private void AddObjects(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            var obj = GameObject.Instantiate(prefab);
            prefab.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }
    public void Update()
    {
        ClearPool();
    }
    public void ClearPool()
    {
        while(pool.Count > amount)
        {
            Destroy(pool.Dequeue().gameObject);
        }
    }
}
