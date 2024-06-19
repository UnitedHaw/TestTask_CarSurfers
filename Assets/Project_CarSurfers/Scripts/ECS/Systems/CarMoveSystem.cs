using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;


namespace Assets.Project_CarSurfers.Scripts.ECS.Systems
{
    public class CarMoveSystem : IEcsRunSystem
    {
        private EcsPoolInject<Car> _carComponentPool;
        private EcsFilterInject<Inc<Car>> _carComponentFilter;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _carComponentFilter.Value)
            {
                var car = _carComponentPool.Value.Get(entity);
                var direction = car.Direction;
                var controller = car.CarController;
                controller.GoForward();

                if (direction == Vector2.zero) continue;

                controller.TurnByAxis(car.Direction.x);
            }
        }
    }
}
