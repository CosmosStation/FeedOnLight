using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AbsorbItem : MonoBehaviour
{
    public string state;

    private List<Tween> _tweens;
    private ParticleSystem _particle;
    
    // Start is called before the first frame update
    void Start()
    {
        state = "idle";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Absorb()
    {
        state = "absorbing";
        DOTween.Pause("pulsing");
        // transform.localScale = new Vector3(1, 1, 1);
        DOTween.Play("absorbing");

        _particle = gameObject.GetComponentInChildren<ParticleSystem>();
        _particle.Play();
        
        // var emission = _particle.emission;
        // emission.enabled = true;
    }
}
