using Assets.Project_CarSurfers.Scripts.Controllers;
using Reflex.Attributes;
using UnityEngine;

public class GameController : MonoBehaviour, IGameStateController
{
    [field: SerializeField] public Joystick Joystick { get; private set; }
    [field: SerializeField] public PlayerController CarController { get; private set; }

    [Inject] private IStateChanger _stateChanger;

    private void Start()
    {
        StartGame();
    }

    public void GameOver()
    {
        _stateChanger.ChangeState(GameState.GameOver);
    }

    public void StartGame()
    {
        _stateChanger.ChangeState(GameState.Start);
    }

}
