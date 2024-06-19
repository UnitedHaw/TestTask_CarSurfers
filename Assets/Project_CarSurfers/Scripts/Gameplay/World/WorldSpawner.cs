using Assets.Project_CarSurfers.Scripts.Interfaces;
using Reflex.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class WorldSpawner : MonoBehaviour
{
    [SerializeField] private GameObjectFactory _factory;
    [SerializeField] private WorldPieceView _pfWorldPiece;
    [SerializeField] private int _activeRoadAmount;
    [SerializeField] private float _spawnDistance;
    [SerializeField] private float _heightOffset;
    [Inject] private IPlayer _player;

    protected ObjectPool<WorldPieceView> _roadPool;
    protected Queue<WorldPieceView> _spawnedPieceQueue;

    private Vector3 _nextSpawnPoint;
    private float _pieceLength;
    
    private void Awake()
    {
        _spawnedPieceQueue = new Queue<WorldPieceView>();
        _roadPool = new ObjectPool<WorldPieceView>(
            () => _factory.InstantiateObject(_pfWorldPiece, transform), GetAction, ReleaseAction);
        _pieceLength = _pfWorldPiece.Length;
    }

    private void Start()
    {
        SpawStartPieces();
    }

    protected virtual void SpawStartPieces()
    {
        _nextSpawnPoint = GetFirstSpawnPoint();
        for (int i = 0; i < _activeRoadAmount; i++)
        {
            SpawnPiece(false);
        }
    }

    private void Update()
    {
        if (Vector3.Distance(_player.Transform.position, _nextSpawnPoint) < _spawnDistance)
        {
            SpawnPiece();
        }
    }

    private void SpawnPiece(bool dequeueFirst = true)
    {
        var road = _roadPool.Get();
        road.transform.position = _nextSpawnPoint;
        _nextSpawnPoint = road.transform.position + new Vector3(0, 0, road.Length);

       if (dequeueFirst)
        {
            var lastRoad = _spawnedPieceQueue.Dequeue();
            _roadPool.Release(lastRoad);
        }      

        _spawnedPieceQueue.Enqueue(road);
    }

    private Vector3 GetFirstSpawnPoint()
    {
        return _player.Transform.position - new Vector3(0, _heightOffset, _pieceLength) * _activeRoadAmount / 2;
    }

    protected virtual void ReleaseAction(WorldPieceView road)
    {
        road.Enable(false);
    }

    protected virtual void GetAction(WorldPieceView road)
    {
        road.Enable(true);
    }
}
