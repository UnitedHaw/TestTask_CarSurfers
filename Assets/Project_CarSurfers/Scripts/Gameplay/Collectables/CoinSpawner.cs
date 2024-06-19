using Assets.Project_CarSurfers.Scripts.Gameplay.Collectables;
using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinSpawnConfig _spawnConfig;
    private List<CoinView> _coins;

    private void Awake()
    {
        _coins = new List<CoinView>();
    }

    public void SpawnCoins(WorldPieceView road)
    {
        var width = road.Width/_spawnConfig.MarginOffset;
        var length = road.Length/ _spawnConfig.MarginOffset;
        var batchesAmount = length % _spawnConfig.CoinsInBatch;

        var batchEndPos = Vector3.zero;
        for (int i = 0; i < batchesAmount; i++)
        {
            if(i == 0)
                batchEndPos = SpawnBatch(road.transform.position, road.Width);
            else
                SpawnBatch(batchEndPos, road.Width);
        }
    }

    private Vector3 SpawnBatch(Vector3 startPoint, float width)
    {
        var spawnPoint = Vector3.zero;
        for (int j = 0; j < _spawnConfig.CoinsInBatch; j++)
        {
            var coin = Instantiate(_spawnConfig.PfCoin);
            spawnPoint = startPoint + new Vector3(-width / 2 + _spawnConfig.BorderOffset, 0, j + _spawnConfig.MarginOffset);
            coin.transform.position = spawnPoint;
        }

        return spawnPoint;
    }

    public void RemoveCoins(WorldPieceView road)
    {
        foreach (CoinView coin in _coins)
        {
            Destroy(coin.gameObject);
        }
    }
}
