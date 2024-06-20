using Assets.Project_CarSurfer.Scripts.UI;
using System;
using System.Collections.Generic;


namespace Assets.Project_HyperBoxer.Scripts.Interfaces.UI
{
    public interface ISceneWindow : IDisposable
    {
        public List<UIWindow> UIWindows { get; }
    }
}
