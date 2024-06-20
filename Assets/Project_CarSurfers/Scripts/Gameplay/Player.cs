using Assets.Project_CarSurfer.Scripts.UI;
using Assets.Project_CarSurfers.Scripts.UI.SceneWindows;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Project_CarSurfers.Scripts.Gameplay
{
    public class Player : MonoBehaviour
    {
        [Inject] private GameplayWindow _gamePlayWindow;
        [Inject] private IChangeEvent _stateEvent;
        [Inject] private IGameStateController _gameState;
        [Inject] private PrometeoCarController _playerCarController;

        private PlayerWindow _playerWindow;
        private Rigidbody _rigidbody;
        private int _collectedCoins;

        private void Awake()
        {
            _playerWindow = _gamePlayWindow.GetWindow<PlayerWindow>();
            _rigidbody = GetComponent<Rigidbody>();
            _stateEvent.OnStateChanged += SetState;
        }

        private void SetState(GameState state)
        {
            switch (state)
            {
                case GameState.Start:
                    break;
                case GameState.GameOver:
                    _rigidbody.isKinematic = true;
                    break;
                case GameState.Restart:
                    transform.position = new Vector3(0, 0, transform.position.z);
                    transform.eulerAngles = Vector3.zero;
                    _rigidbody.isKinematic = false;
                    break;
            }
        }

        public void Fail()
        {
            _gameState.GameOver();
        }

        public void AddCoin()
        {
            if (_playerWindow == null)
                _playerWindow = _gamePlayWindow.GetWindow<PlayerWindow>();

            _collectedCoins++;
            _gamePlayWindow.GetWindow<PlayerWindow>().SetCoinsAmount(_collectedCoins);
        }

        private void Update()
        {
            SetSpeed();
        }

        public void SetSpeed()
        {
            var speed = (int)_playerCarController.carSpeed;
            _playerWindow.SetSpeed(speed.ToString());
        }

        private void OnDestroy()
        {
            _stateEvent.OnStateChanged -= SetState;
        }
    }
}
