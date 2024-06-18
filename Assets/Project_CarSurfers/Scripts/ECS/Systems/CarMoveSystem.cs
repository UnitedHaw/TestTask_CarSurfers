﻿using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;


namespace Assets.Project_CarSurfers.Scripts.ECS.Systems
{
    public class CarMoveSystem : IEcsRunSystem
    {
        private EcsPoolInject<CarComponent> _carComponentPool;
        private EcsFilterInject<Inc<CarComponent>> _carComponentFilter;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _carComponentFilter.Value)
            {
                var car = _carComponentPool.Value.Get(entity);
                var controller = car.CarController;
                controller.MoveForwardByAxis(car.Direction.y);
                controller.TurnByAxis(car.Direction.x);
            }
        }
    }
}