using Assets.Project_HyperBoxer.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

namespace Assets.Project_CarSurfers.Scripts.UI.SceneWindows
{
    public class InfoWindow : UIWindow
    {
        private InfoWindowView _infoView;
        public InfoWindow(UIDocument document) : base(document)
        {
            _infoView = new InfoWindowView(document);
            _view = _infoView;
        }

        public void SetSpeed(string speed)
        {
            _infoView.Speed.text = speed + " KM/H";
        }

        public void SetCoinsAmount(int coins)
        {
            _infoView.Coins.text = coins.ToString();
        }
    }
}
