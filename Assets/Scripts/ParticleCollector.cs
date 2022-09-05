using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollector : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private List<ParticleSystem.Particle> _particles = new List<ParticleSystem.Particle>();
    
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleTrigger()
    {
        int triggeredParticles = _particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, _particles);

        for (int i = 0; i < triggeredParticles; i++)
        {
            ParticleSystem.Particle particle = _particles[i];
            particle.remainingLifetime = 0;
            _particles[i] = particle;
        }
        
        _particleSystem.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, _particles);
    }
}
