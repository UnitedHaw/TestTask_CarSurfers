using Assets.Project_CarSurfers.Scripts.ECS.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Reflex.Attributes;
using System;
using UnityEngine;

namespace Assets.Project_CarSurfers.Scripts
{
    public class PlayerInputSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorldInject _world;
        private EcsPoolInject<PlayerTag> _playerTagPool;
        private EcsPoolInject<Car> _carComponentPool;
        private EcsCustomInject<Joystick> _joystick;
        private EcsCustomInject<JoystickCarController> _carController;
        private int _playerEntity;

        public void Init(IEcsSystems systems)
        {
            _playerEntity = _world.Value.NewEntity();

            _playerTagPool.Value.Add(_playerEntity);
            _carComponentPool.Value.Add(_playerEntity);
            
            ref var playerComponent = ref _carComponentPool.Value.Get(_playerEntity);
            playerComponent.CarController = _carController.Value;
        }

        public void Run(IEcsSystems systems)
        {
            if (!_carComponentPool.Value.Has(_playerEntity)) return;

            ref var playerComponent = ref _carComponentPool.Value.Get(_playerEntity);
            playerComponent.Direction = _joystick.Value.Direction;
        }
    }
}
