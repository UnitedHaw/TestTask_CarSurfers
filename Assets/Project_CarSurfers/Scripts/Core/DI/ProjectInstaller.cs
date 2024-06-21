using Reflex.Core;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private UIDocument _uiDocument;
    [SerializeField] private VFXController _vfxController;
    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        Application.targetFrameRate = 120;

        var container = Instantiate(new GameObject("ProjectInstallers"));
        DontDestroyOnLoad(container);

        var document = Instantiate(_uiDocument, container.transform);
        Instantiate(_vfxController, container.transform);

        containerBuilder
            .AddSingleton(document);
    }
}
