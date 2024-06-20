using Assets.Project_CarSurfers.Scripts.Gameplay.Collectables;
using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinMapper
{
    private CoinSpawnConfig _spawnConfig;
    private List<Vector3> _coinsPositions;
    private float _linesStep;
    public CoinMapper(CoinSpawnConfig spawnConfig)
    {
        _spawnConfig = spawnConfig;
        _coinsPositions = new List<Vector3>();
    }

    public List<Vector3> GetSpawnPositions(PlateView road)
    {
        _coinsPositions.Clear();
        var roadCapacity = road.Length/_spawnConfig.MarginOffset;
        var batchesAmount = roadCapacity % _spawnConfig.CoinsInBatch;
        var batchLength = _spawnConfig.CoinsInBatch * _spawnConfig.MarginOffset;
        _linesStep = road.Width / (_spawnConfig.Lines % 2 == 0 ? _spawnConfig.Lines : _spawnConfig.Lines - 1);

        for (int i = 0; i < batchesAmount; i++)
        {
            var spawnChance = Random.Range(0, 101);
            if (spawnChance > _spawnConfig.SpawnChance)
                continue;

            var line = Random.Range(0, _spawnConfig.Lines);

            var startPos = road.transform.position + new Vector3(0, 0, i * batchLength);
            InitBatch(startPos, (line * _linesStep) - road.Width / 2);
        }

        return _coinsPositions;
    }

    private void InitBatch(Vector3 startPoint, float line)
    {
        var borderOffset = 0f;
        if (line != 0)
            borderOffset = line > 0 ? -_spawnConfig.BorderOffset : _spawnConfig.BorderOffset;

        var spawnPoint = Vector3.zero;
        for (int j = 0; j < _spawnConfig.CoinsInBatch; j++)
        {
            spawnPoint = startPoint + new Vector3(line + borderOffset
                , _spawnConfig.HeighOffset, j * _spawnConfig.MarginOffset);
            _coinsPositions.Add(spawnPoint);
        }
    }
}
