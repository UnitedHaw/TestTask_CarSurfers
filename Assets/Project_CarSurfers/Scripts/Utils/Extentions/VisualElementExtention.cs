using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

namespace Assets.Project_CarSurfers.Scripts.Utils.Extentions
{
    public static class VisualElementExtention
    {
        public static void SetActive(this VisualElement element, bool active)
        {
            if(active)
                element.style.display = DisplayStyle.Flex;
            else
                element.style.display = DisplayStyle.None;

        }
    }
}
