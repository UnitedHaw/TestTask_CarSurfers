using Reflex.Core;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private UIDocument _uiDocument;
    [SerializeField] private VFXController _vfxController;
    [SerializeField] private SoundController _soundController;
    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        Application.targetFrameRate = 120;

        var container = Instantiate(new GameObject("ProjectInstallers"));
        DontDestroyOnLoad(container);
     
        Instantiate(_vfxController, container.transform);
        Instantiate(_soundController, container.transform);

        containerBuilder
            .AddSingleton(Instantiate(_uiDocument, container.transform));
    }
}
