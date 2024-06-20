﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

namespace Assets.Project_HyperBoxer.Scripts.UI
{
    public abstract class UIWindow
    {
        protected UIDocument _rootDocument;
        protected WindowView _view;
        public UIWindow(UIDocument document)
        {
            _rootDocument = document;
        }
    }
}
