using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    [SerializeField] private ParticleSystem rainSystem;

    private ParticleSystem.EmissionModule emissionModule;

    private void Awake()
    {
        EnsureModule();
    }

    private void EnsureModule()
    {
        emissionModule = rainSystem.emission;
    }
    public bool RainEnabled
    {
        get
        {
            EnsureModule();
            return emissionModule.enabled;
        }
        set
        {
            EnsureModule();
            emissionModule.enabled = value;
        }
    }

    public float RainRate
    {
        get
        {
            EnsureModule();
            return emissionModule.rateOverTime.constant;
        }
        set
        {
            EnsureModule();
            emissionModule.rateOverTime = value;
        }
    }
}
