using Assets.Project_CarSurfers.Scripts.UI.SceneWindows;
using Assets.Project_HyperBoxer.Scripts.Interfaces.UI;
using Assets.Project_HyperBoxer.Scripts.UI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

namespace Assets.Project_HyperBoxer.Scripts.UI
{
    public class GameplayWindow : SceneWindow
    {
        public GameplayWindow(UIDocument rootDocument, IStateChanger stateChanger) : base(rootDocument)
        {
            _uiWindows.Add(new PlayerWindow(_rootDocument, stateChanger));
        }
    }
}
