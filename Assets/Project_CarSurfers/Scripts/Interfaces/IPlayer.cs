using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project_CarSurfers.Scripts.Interfaces
{
    public interface IPlayer
    {
        public Transform Transform { get; }

        public void AddCoin();

        public void SetSpeed();
    }
}
