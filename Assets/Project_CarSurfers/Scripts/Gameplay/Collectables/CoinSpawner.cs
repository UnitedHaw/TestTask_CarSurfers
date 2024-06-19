using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _pfCoin;
    [SerializeField] private float _spawnOffset;
    [SerializeField] private float _heighOffset;
    private List<Coin> _coins;
    private float _spawnChance = .3f;

    private void Awake()
    {
        _coins = new List<Coin>();
    }

    public async void SpawnCoins(WorldPieceView road)
    {
        var roadStartPoint = road.StartPoint;

        for (int z = 0; z < road.Length; z++)
        {
            if (z % _spawnOffset != 0) continue;

            for (int x = 0; x < road.Width; x++)
            {
                if (x % _spawnOffset != 0) continue;

                var chance = UnityEngine.Random.Range(0f, 1f);

                if(chance > _spawnChance)
                {
                    var spawnPosition = roadStartPoint + new Vector3(x, _heighOffset, z);
                    _coins.Add(Instantiate(_pfCoin, spawnPosition, Quaternion.identity));
                }
                await UniTask.NextFrame();
            }
        }
    }

    public void RemoveCoins(WorldPieceView road)
    {
        foreach (Coin coin in _coins)
        {
            Destroy(coin.gameObject);
        }
    }
}
