using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Project_CarSurfers.Scripts.Gameplay.World
{
    public class RoadView : PlateView
    {
        private CoinView[] _coins;

        private void Start()
        {
            _coins = GetComponentsInChildren<CoinView>();
        }

        protected override void DisableAction()
        {
            gameObject.SetActive(false);
        }

        protected override void EnableAction()
        {
            gameObject.SetActive(true);

            if (_coins == null) return;

            foreach (var coin in _coins)
            {
                coin.Enable(true);
            }
        }
    }
}
