﻿using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Assets.Project_CarSurfer.Scripts.UI.Base
{
    public class SceneWindow : IDisposable
    {
        protected UIDocument _rootDocument;
        protected List<UIWindow> _uiWindows;

        public SceneWindow(UIDocument rootDocument)
        {
            _rootDocument = rootDocument;
            _uiWindows = new List<UIWindow>();
        }

        public void Dispose()
        {
            foreach(UIWindow window in _uiWindows)
            {
                window.Dispose();
            }
        }

        public T GetWindow<T>() where T : UIWindow
        {
            return (T)_uiWindows.Find(window  => window.GetType() == typeof(T));
        }
    }
}
