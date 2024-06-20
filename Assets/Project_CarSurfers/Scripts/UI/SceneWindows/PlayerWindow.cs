using Assets.Project_CarSurfer.Scripts.UI;
using Assets.Project_CarSurfers.Scripts.Utils.Extentions;
using System;
using UnityEngine.UIElements;

namespace Assets.Project_CarSurfers.Scripts.UI.SceneWindows
{
    public class PlayerWindow : UIWindow
    {     
        public event Action OnRestart
        {
            add => _playerView.RestartButton.clicked += value;
            remove => _playerView.RestartButton.clicked -= value;
        }

        private IStateChanger _gameChangeEvent;
        private PlayerWindowView _playerView;

        public PlayerWindow(UIDocument document, IStateChanger stateChanger) : base(document)
        {
            _playerView = new PlayerWindowView(document);
            _gameChangeEvent = stateChanger;
            _view = _playerView;

            _gameChangeEvent.OnStateChanged += SetState;
            OnRestart += () => _gameChangeEvent.ChangeState(GameState.Restart);
        }

        private void SetState(GameState state)
        {
            switch (state)
            {
                case GameState.GameOver:
                    _playerView.RestartButton.SetActive(true);
                    break;
                case GameState.Restart or GameState.Start:
                    _playerView.RestartButton.SetActive(false);
                    break;
            }
        }

        public void SetSpeed(string speed)
        {
            _playerView.Speed.text = speed + " KM/H";
        }

        public void SetCoinsAmount(int coins)
        {
            _playerView.Coins.text = coins.ToString();
        }

        protected override void Purify()
        {
            //_gameChangeEvent.OnStateChanged -= SetState;
            OnRestart -= () => _gameChangeEvent.ChangeState(GameState.Restart);
        }

        internal void SetCoinsAmount(object collectedCoins)
        {
            throw new NotImplementedException();
        }
    }
}
