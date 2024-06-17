using Assets.Project_HyperBoxer.Scripts.UI;
using Assets.Project_HyperBoxer.Scripts.UI.Base;
using Reflex.Attributes;
using Reflex.Core;
using UnityEngine;
using UnityEngine.UIElements;

public class GameInstaller : MonoBehaviour
    //, IInstaller
{
    [Inject] private GameplayWindow _sceneWindow;
    [Inject] private UIDocument _uiDocument;


    private void Start()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
