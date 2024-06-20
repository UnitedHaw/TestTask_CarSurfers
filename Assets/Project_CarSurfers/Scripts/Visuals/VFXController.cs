using Assets.Project_CarSurfers.Scripts.ScriptableObjects;
using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class VFXController : MonoBehaviour
{
    [SerializeField] private VfxDataSO _vfxDataSO;
    [SerializeField] private int _disableTime;
    private Dictionary<VfxType, ObjectPool<ParticleSystem>> _particles;

    public static VFXController Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
            
        Instance = this;
        
        InitializeVfx();
    }

    private void InitializeVfx()
    {
        _particles = new Dictionary<VfxType, ObjectPool<ParticleSystem>>();
        foreach (var suit in (VfxType[])Enum.GetValues(typeof(VfxType)))
        {
            SetupVFX(_vfxDataSO.GetVfxData(suit));
        }
    }
    private void SetupVFX(VfxData vfxData)
    {
        if (_particles.ContainsKey(vfxData.ParticleType)) 
            return;

        _particles[vfxData.ParticleType] = new ObjectPool<ParticleSystem>(() => Instantiate(vfxData.Particle, transform));
    }

    public async void PlayParticle(VfxType vfxKey, Vector3 position)
    {
        var particle = _particles[vfxKey].Get();
        particle.gameObject.SetActive(true);
        particle.transform.position = position;
        particle.Play();

        await UniTask.Delay(_disableTime * 1000);

        particle.gameObject.SetActive(false);
        _particles[vfxKey].Release(particle);
    }
}
