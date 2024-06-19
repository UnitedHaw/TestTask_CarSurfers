using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Project_CarSurfers.Scripts.ScriptableObjects
{
    public class RoadFactory : GameObjectFactory
    {
        public WorldPieceView InstantiateCoin(WorldPieceView coinPrefab)
        {
            return InstantiateObject(coinPrefab);
        }
    }
}
