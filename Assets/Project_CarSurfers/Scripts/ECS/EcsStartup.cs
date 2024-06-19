using Assets.Project_CarSurfers.Scripts;
using Assets.Project_CarSurfers.Scripts.ECS.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Reflex.Attributes;
using UnityEngine;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {
        [Inject] GameInstaller _gameInstaller;
        EcsWorld _world;
        IEcsSystems _fixedSystem;
        IEcsSystems _systems;

        void Start () {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            _systems
                .Add(new PlayerInputSystem())
                .Add(new CarMoveSystem())

#if UNITY_EDITOR
                .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ())

#endif
                .Inject(_gameInstaller.Joystick)
                .Inject(_gameInstaller.CarController)
                .Init ();

            _fixedSystem = new EcsSystems (_world);
            _fixedSystem
                .Add(new CarMoveSystem())
                .Inject(_gameInstaller.Joystick)
                .Inject(_gameInstaller.CarController)
            .Init();
        }

        void Update () {
            _systems?.Run ();
        }

        void FixedUpdate()
        {
            _fixedSystem?.Run();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _fixedSystem.Destroy();
                _systems = null;
                _fixedSystem = null;   
            }

            if (_world != null) {
                _world.Destroy ();
                _world = null;
            }
        }
    }
}