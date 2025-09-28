using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    [SerializeField] private int initPoolSize;
    [SerializeField] private PooledObject ObjectToPool;

    private Stack<PooledObject> pool;
    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
        
        SetupPool();
    }

    private void SetupPool()
    {
        pool = new Stack<PooledObject>();
        PooledObject instance = null;

        for (int i = 0; i < initPoolSize; i++)
        {
            instance = Instantiate(ObjectToPool);
            instance.Pool = this;
            instance.gameObject.SetActive(false);
            pool.Push(instance);
        }

    }

    public PooledObject GetPooledObject()
    {
        if (pool.Count == 0)
        {
            PooledObject newInstance = Instantiate(ObjectToPool);
            newInstance.Pool = this;
            return newInstance;
        }
        PooledObject nextInstance = pool.Pop();
        nextInstance.gameObject.SetActive(true);
        return nextInstance;
    }

    public void ReturnToPool(PooledObject pooledObject)
    {
        pool.Push(pooledObject);
        pooledObject.gameObject.SetActive(false);
    }

}
