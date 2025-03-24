using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    private BuildingList _buildingList;
    private Dictionary<string, Queue<GameObject>> PoolDictionary;
    private GameObject _poolHandler;

    public PoolManager(BuildingList buildingList)
    {
        _buildingList = buildingList;
    }
    public void InitPools()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        _poolHandler = new GameObject("PoolHandler");

        foreach (Building pool in _buildingList.Buildings)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.PoolingSize; i++)
            {
                GameObject buffer = GameObject.Instantiate(pool.Prefab, _poolHandler.transform);
                buffer.SetActive(false);
                objectPool.Enqueue(buffer);
            }
            PoolDictionary.Add(pool.PoolingName, objectPool);
        }
    }
    public GameObject InstantiateFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!PoolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with " + tag + " tag doesn't exist");
            return null;
        }
        GameObject objectToSpawn = PoolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        PoolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
