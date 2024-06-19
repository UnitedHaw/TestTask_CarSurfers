using Assets.Project_CarSurfers.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project_CarSurfers.Scripts.Controllers
{
    public class PlayerController : JoystickCarController, IPlayer
    {
        public Transform Transform => transform;
    }
}
