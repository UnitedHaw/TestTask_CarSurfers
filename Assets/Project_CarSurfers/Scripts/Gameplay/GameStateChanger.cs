using System;

public enum GameState
{
    None,
    Start,
    GameOver,
    Restart
}

public class GameStateChanger : IStateChanger
{
    public event Action<GameState> OnStateChanged;

    private GameState _currentState;
    public void ChangeState(GameState state)
    {
        if (_currentState == state) return;

        OnStateChanged?.Invoke(state);
        _currentState = state;
        switch (state)
        {
            case GameState.Start:
                break;
            case GameState.GameOver:
                break;
            case GameState.Restart:
                break;
        }
    }
}
