using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project_CarSurfers.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "VfxData", menuName = "VFX/VfxData")]
    public class VfxDataSO : ScriptableObject
    {
        [field: SerializeField] public List<VfxData> VfxDatas { get; private set; }

        public VfxData GetVfxData(VfxType particleVFX)
        {
            return VfxDatas.Find(vfx => vfx.ParticleType == particleVFX);
        }
    }
}
