using Assets.Project_CarSurfers.Scripts;
using Assets.Project_CarSurfers.Scripts.Gameplay;
using Reflex.Core;
using UnityEngine;

public class GameInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private Player _player;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder
            .AddSingleton(_gameController, typeof(GameController), typeof(IGameStateController))
            .AddSingleton(_player)
            .AddSingleton(_gameController.CarController,
                typeof(JoystickCarController),
                typeof(PrometeoCarController));
    }
}
