using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class VfxData
{
    [field: SerializeField] public VfxType ParticleType { get; private set; }
    [field: SerializeField] public ParticleSystem Particle { get; private set; }
}
