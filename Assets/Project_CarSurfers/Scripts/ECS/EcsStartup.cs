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
        }

        void Update () {
            // process systems here.
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                // list of custom worlds will be cleared
                // during IEcsSystems.Destroy(). so, you
                // need to save it here if you need.
                _systems.Destroy ();
                _systems = null;
            }
            
            // cleanup custom worlds here.
            
            // cleanup default world.
            if (_world != null) {
                _world.Destroy ();
                _world = null;
            }
        }
    }
}