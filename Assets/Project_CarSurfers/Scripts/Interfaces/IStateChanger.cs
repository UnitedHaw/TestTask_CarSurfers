using System;

public interface IStateChanger : IChangeEvent
{
    public void ChangeState(GameState state);
}

public interface IChangeEvent
{
    public event Action<GameState> OnStateChanged;
}