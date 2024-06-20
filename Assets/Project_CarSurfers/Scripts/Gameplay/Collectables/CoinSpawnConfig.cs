using System;
using UnityEngine;

namespace Assets.Project_CarSurfers.Scripts.Gameplay.Collectables
{
    [Serializable]
    public class CoinSpawnConfig
    {
        [field: SerializeField] public CoinView PfCoin { get; private set; }
        [field: SerializeField] public int Lines { get; private set; }
        [field: SerializeField] public int CoinsInBatch { get; private set; }
        [field: SerializeField] public float MarginOffset { get; private set; }
        [field: SerializeField] public float BorderOffset { get; private set; }
        [field: SerializeField] public float HeighOffset { get; private set; }
        [field: SerializeField, Range(0,100)] public int SpawnChance { get; private set; }
    }
}
