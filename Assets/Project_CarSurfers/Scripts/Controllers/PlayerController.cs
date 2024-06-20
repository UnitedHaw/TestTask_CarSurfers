using Assets.Project_CarSurfers.Scripts.Interfaces;
using Assets.Project_CarSurfers.Scripts.UI.SceneWindows;
using Assets.Project_HyperBoxer.Scripts.UI;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project_CarSurfers.Scripts.Controllers
{
    public class PlayerController : JoystickCarController, IPlayer
    {
        [Inject] private GameplayWindow _gamePlayWindow;
        private int _collectedCoins;
        public Transform Transform => transform;

        private InfoWindow _infoWindow;

        public void AddCoin()
        {
            if (_infoWindow == null)
                _infoWindow = _gamePlayWindow.GetWindow<InfoWindow>();

            _collectedCoins++;
            _gamePlayWindow.GetWindow<InfoWindow>().SetCoinsAmount(_collectedCoins);
        }

        public void SetSpeed()
        {
            if (_infoWindow == null)
                _infoWindow = _gamePlayWindow.GetWindow<InfoWindow>();

            var speed = (int)carSpeed;
            _infoWindow.SetSpeed(speed.ToString());
        }

        private void LateUpdate()
        {
            SetSpeed();
        }
    }
}
