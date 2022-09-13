using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    [SerializeField] private float energyAmount = 100;
    [SerializeField] private float decreasePoints = 1;
    [SerializeField] private float timeStep = 1;
    [SerializeField] private Light lightSource;
    [SerializeField] private Image progressBarImage;

    private float _time = 0;
    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= timeStep)
        {
            _time = 0;
            this.DecreaseEnergy(decreasePoints);
        }
    }

    public void DecreaseEnergy(float amount)
    {
        energyAmount -= amount;
        if (energyAmount > 0)
        {
            lightSource.intensity = energyAmount;
            progressBarImage.rectTransform.localScale = new Vector3(energyAmount / 100f, 1, 1);
        }
        else
        {
            progressBarImage.rectTransform.localScale = new Vector3(0, 1, 1);
            Debug.Log("Dead");
            this.enabled = false;
        }
    }
}
