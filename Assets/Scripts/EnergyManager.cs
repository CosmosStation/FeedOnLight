using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    public bool increaseMode = false;
    
    [SerializeField] private float startEnergyAmount = 100;
    [SerializeField] private float decreasePoints = 1;
    [SerializeField] private float increasePoints = 3;
    [SerializeField] private float timeStep = 1;
    [SerializeField] private Light lightSource;
    [SerializeField] private Image progressBarImage;

    private float _energyAmount;
    private float _time = 0;

    private void Start()
    {
        _energyAmount = startEnergyAmount;
        DOTween.defaultEaseType = Ease.Linear;
        Debug.Log(Color.white);
        Debug.Log(Color.black);
    }

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= timeStep)
        {
            _time = 0;
            if (increaseMode)
            {
                this.IncreaseEnergy(increasePoints);
            }
            else
            {
                this.DecreaseEnergy(decreasePoints);
            }
        }
    }

    public void DecreaseEnergy(float amount)
    {
        _energyAmount -= amount;
        if (_energyAmount > 0)
        {
            lightSource.DOIntensity(_energyAmount, timeStep);
            lightSource.DOColor(new Color(_energyAmount / 100, _energyAmount / 100, _energyAmount / 100, _energyAmount / 100), timeStep);
            progressBarImage.rectTransform.DOSizeDelta(new Vector2(500 * _energyAmount / 100, 15), timeStep);
        }
        else
        {
            progressBarImage.rectTransform.sizeDelta = new Vector2(0, 15);
            Debug.Log("Dead");
            SceneManager.LoadScene("StartMenu");
            this.enabled = false;
        }
    }

    public void IncreaseEnergy(float amount)
    {
        
        if (_energyAmount < startEnergyAmount)
        {
            _energyAmount += amount;
            lightSource.DOIntensity(_energyAmount, timeStep);
            progressBarImage.rectTransform.DOSizeDelta(new Vector2(500 * _energyAmount / 100, 15), timeStep);
        }
        else
        {
            _energyAmount = startEnergyAmount;
            lightSource.intensity = _energyAmount;
            progressBarImage.rectTransform.sizeDelta = new Vector2(500, 15);
        }
    }
}
