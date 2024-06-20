using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

namespace Assets.Project_HyperBoxer.Scripts.UI.Base
{
    public class SceneWindow
    {
        protected UIDocument _rootDocument;
        protected List<UIWindow> _uiWindows;

        public SceneWindow(UIDocument rootDocument)
        {
            _rootDocument = rootDocument;
            _uiWindows = new List<UIWindow>();
        }

        public T GetWindow<T>() where T : UIWindow
        {
            return (T)_uiWindows.Find(window  => window.GetType() == typeof(T));
        }
    }
}
