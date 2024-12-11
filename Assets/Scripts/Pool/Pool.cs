using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Pool<T> : MonoBehaviour where T : PoolableObject<T>
{
    [SerializeField] private T _prefab;

    private int _maxSize = 100;
    private int _defaultCapacity = 50;
    private List<T> _createdObjects;
    private ObjectPool<T> _pool;

    private void Awake()
    {
        _createdObjects = new List<T>();

        _pool = new ObjectPool<T>(
            createFunc: () => CreateObject(),
            actionOnGet: t => t.gameObject.SetActive(true),
            actionOnRelease: t => t.gameObject.SetActive(false),
            actionOnDestroy: t => Destroy(t.gameObject),
            collectionCheck: true,
            defaultCapacity: _defaultCapacity,
            maxSize: _maxSize);
    }

    public T GetObjects()
    {
        T Object = _pool.Get();
        _createdObjects.Add(Object);
        return Object;
    }

    public virtual void ReleaseObjects(T t)
    {
        if (_createdObjects.Contains(t))
        {
            _pool.Release(t);
            _createdObjects.Remove(t);
        }
    }

    public void Clear()
    {
        foreach (T t in _createdObjects.ToArray())
        {
            ReleaseObjects(t);
        }
    }

    private T CreateObject() => Instantiate(_prefab);
}