using Assets.Project_CarSurfers.Scripts.Gameplay.Collectables;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Project_CarSurfers.Scripts.ScriptableObjects
{
    [CreateAssetMenu]
    public class RoadFactory : PlateFactory
    {
        [SerializeField] private CoinSpawnConfig _coinSpawnConfig;
        private CoinMapper _coinMapper;

        protected override PlateView GetPlate(PlateType type, Transform parent = null)
        {
            var road = base.GetPlate(type, parent);
            SetupCoins(road);
            return road;
        }

        private void SetupCoins(PlateView road)
        {
            if (_coinMapper == null)
            {
                _coinMapper = new CoinMapper(_coinSpawnConfig);
            }         

            var coinsPositions = _coinMapper.GetSpawnPositions(road);
            foreach (var position in coinsPositions)
            {
                var coin = Instantiate(_coinSpawnConfig.PfCoin, position, Quaternion.identity);
                coin.transform.parent = road.transform;
            }
        }
    }
}
