using Assets.Project_CarSurfers.Scripts;
using Assets.Project_CarSurfers.Scripts.Controllers;
using Assets.Project_CarSurfers.Scripts.Interfaces;
using Assets.Project_HyperBoxer.Scripts.UI;
using Assets.Project_HyperBoxer.Scripts.UI.Base;
using Reflex.Attributes;
using Reflex.Core;
using UnityEngine;
using UnityEngine.UIElements;

public class GameInstaller : MonoBehaviour, IInstaller
{
    [field: SerializeField] public Joystick Joystick { get; private set; }
    [field: SerializeField] public PlayerController CarController { get; private set; }
    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder
            .AddSingleton(this)
            .AddSingleton(CarController,
                typeof(JoystickCarController),
                typeof(PrometeoCarController),
                typeof(IPlayer));
    }
}
