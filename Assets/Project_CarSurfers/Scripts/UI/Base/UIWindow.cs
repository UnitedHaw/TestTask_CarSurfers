using System;
using UnityEngine.UIElements;

namespace Assets.Project_CarSurfer.Scripts.UI
{
    public abstract class UIWindow : IDisposable
    {
        protected UIDocument _rootDocument;
        protected WindowView _view;
        public UIWindow(UIDocument document)
        {
            _rootDocument = document;
        }

        protected abstract void Purify();

        public void Dispose()
        {
            Purify();
        }
    }
}
