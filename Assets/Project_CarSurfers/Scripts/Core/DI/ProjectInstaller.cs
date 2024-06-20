using Assets.Project_HyperBoxer.Scripts.UI;
using Reflex.Core;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private UIDocument _uiDocument;
    [SerializeField] private VFXController _vfxController;
    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        var container = Instantiate(new GameObject("ProjectInstallers"));
        DontDestroyOnLoad(container);

        var document = Instantiate(_uiDocument, container.transform);
        var vfxController = Instantiate(_vfxController, container.transform);

        containerBuilder
            .AddSingleton(document)
            .AddSingleton(vfxController)
            .AddSingleton(new GameplayWindow(document));
    }
}
