using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject prefab;
    private Queue<GameObject> objects = new Queue<GameObject>();

    public int instances = 0;


    public void Awake()
    {
        AddObjects(instances);
    }
    public GameObject GetObject()
    {
        if(objects.Count == 0)
        {
            AddObjects(1);
        }
        return objects.Dequeue();
    }
    private void AddObjects(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            var newObj = GameObject.Instantiate(prefab);
            newObj.SetActive(false);
            newObj.GetComponent<IGameObjectPooler>().pool = this;
            objects.Enqueue(newObj);
        }
    }
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        objects.Enqueue(obj);
    }
}

public interface IGameObjectPooler
{
    GameObjectPool pool { get; set; }
}
