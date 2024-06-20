using Assets.Project_CarSurfer.Scripts.UI;
using UnityEngine.UIElements;

namespace Assets.Project_CarSurfers.Scripts.UI.SceneWindows
{
    public class PlayerWindowView : WindowView
    {
        public Label Speed;
        public Label Coins;
        public Button RestartButton;

        public PlayerWindowView(UIDocument document) : base(document)
        {
            Speed = _rootDocument.rootVisualElement.Q<Label>("Speed");
            Coins = _rootDocument.rootVisualElement.Q<Label>("Coins");
            RestartButton = _rootDocument.rootVisualElement.Q<Button>("RestartButton");
        }
    }
}
