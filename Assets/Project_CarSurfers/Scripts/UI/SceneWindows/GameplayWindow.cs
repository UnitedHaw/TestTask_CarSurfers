using Assets.Project_CarSurfer.Scripts.UI.Base;
using Assets.Project_CarSurfers.Scripts.UI.SceneWindows;
using UnityEngine.UIElements;

namespace Assets.Project_CarSurfer.Scripts.UI
{
    public class GameplayWindow : SceneWindow
    {
        public GameplayWindow(UIDocument rootDocument, IStateChanger stateChanger) : base(rootDocument)
        {
            _uiWindows.Add(new PlayerWindow(_rootDocument, stateChanger));
        }
    }
}
