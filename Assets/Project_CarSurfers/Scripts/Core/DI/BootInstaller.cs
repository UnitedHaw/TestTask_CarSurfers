using Assets.Project_HyperBoxer.Scripts.UI;
using Reflex.Attributes;
using Reflex.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BootInstaller : MonoBehaviour
{
    [Inject] private UIDocument _uiDocument;
    private void Start()
    {
        var scene = SceneManager.LoadScene("Gameplay", new LoadSceneParameters(LoadSceneMode.Single));
        var stateChanger = new GameStateChanger();

        ReflexSceneManager.PreInstallScene(scene, builder => builder
            .AddSingleton(new GameplayWindow(_uiDocument, stateChanger))
            .AddSingleton(stateChanger, typeof(GameStateChanger), typeof(IStateChanger), typeof(IChangeEvent)));         
    }
}
