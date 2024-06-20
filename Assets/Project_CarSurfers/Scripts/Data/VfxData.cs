using System;
using UnityEngine;

[Serializable]
public class VfxData
{
    [field: SerializeField] public VfxType ParticleType { get; private set; }
    [field: SerializeField] public ParticleSystem Particle { get; private set; }
}
