using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    // Light
	[Header("Light")] [SerializeField] private Light _light;
    
    public void Turn()
    {
        _light.intensity = _light.intensity > 0 ? 0 : 1;
    }
}
