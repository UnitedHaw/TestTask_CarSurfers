using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project_CarSurfers.Scripts.ScriptableObjects
{
    public enum PlateType
    {
        Road,
        Water
    }
    public abstract class PlateFactory : GameObjectFactory
    {
        [SerializeField] protected PlateView _pfRoad;
        [SerializeField] protected PlateView _pfWater;
        [SerializeField] protected PlateType _plateType;
        public PlateView Prefab => GetPrefab();

        public PlateView Get(Transform parent = null)
        {
            return GetPlate(_plateType, parent);
        }

        protected virtual PlateView GetPlate(PlateType type, Transform parent = null)
        {
            switch (type)
            {
                case PlateType.Road:
                    return InstantiateObject(_pfRoad, parent);
                case PlateType.Water:
                    return InstantiateObject(_pfWater, parent);
                default:
                    return null;
            }
        }

        protected PlateView GetPrefab()
        {
            switch (_plateType)
            {
                case PlateType.Road:
                    return _pfRoad;
                case PlateType.Water:
                    return _pfWater;
                default:
                    return null;
            }
        }
    }
}
