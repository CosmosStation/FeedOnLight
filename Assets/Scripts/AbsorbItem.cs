using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class AbsorbItem : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle;

    [SerializeField] 
    private GameObject player;
    [SerializeField] 
    private EnergyManager playerEnergyManager;

    private string _state;
    private List<Tween> _tweens;
    
    private void Start()
    {
        _state = "idle";
    }

    public void Absorb(Vector3 forward)
    {
        _state = "absorbing";
        DOTween.Pause("pulsing");
        DOTween.Play("absorbing");

        particle.Play();
        playerEnergyManager.increaseMode = true;
    }

    private void Update()
    {
        if (_state == "absorbing")
        {
            particle.transform.LookAt(player.transform);
            if (particle.isStopped)
            {
                playerEnergyManager.increaseMode = false;        
                Destroy(gameObject);
            }
        }
    }
}
