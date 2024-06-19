using Reflex.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private List<RoadView> _roadVairiants;
    [SerializeField] private GameObjectFactory _factory;
    [SerializeField] private int _activeRoadAmount;
    [SerializeField] private float _spawnDistance;

    [Inject] private PrometeoCarController _carController;

    private ObjectPool<RoadView> _roadPool;
    private Queue<RoadView> _spawnedRoadQueue;

    private Vector3 _nextSpawnPoint;
    private void Awake()
    {
        _spawnedRoadQueue = new Queue<RoadView>();
        _roadPool = new ObjectPool<RoadView>(
            () => _factory.InstantiateObject(_roadVairiants[0], transform), GetAction, ReleaseAction);
    }

    private void Start()
    {
        _nextSpawnPoint = _carController.transform.position - new Vector3(0, 0, 30);
        for (int i = 0; i < _activeRoadAmount; i++)
        {
            SpawnRoad(false);
        }
    }

    private void Update()
    {
        if (Vector3.Distance(_carController.transform.position, _nextSpawnPoint) < _spawnDistance)
        {
            SpawnRoad();
        }
    }

    private void SpawnRoad(bool dequeueFirst = true)
    {
        var road = _roadPool.Get();
        road.transform.position = _nextSpawnPoint;
        _nextSpawnPoint = road.transform.position + new Vector3(0, 0, road.Length);

       if (dequeueFirst)
        {
            var lastRoad = _spawnedRoadQueue.Dequeue();
            _roadPool.Release(lastRoad);
        }      

        _spawnedRoadQueue.Enqueue(road);
    }

    private void ReleaseAction(RoadView road)
    {
        road.Enable(false);
    }

    private void GetAction(RoadView road)
    {
        road.Enable(true);
    }
}
