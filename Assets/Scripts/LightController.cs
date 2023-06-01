using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
	[Header("Light")] [SerializeField] private Light _light;

    Dictionary<string, Color> colors = new Dictionary<string, Color>();

    public void Awake()
    {
        colors.Add("white", Color.white);
        colors.Add("blue", Color.blue);
        colors.Add("pink", new Color(255, 105, 180));
        colors.Add("yellow", Color.yellow);
        colors.Add("green", Color.green);
        colors.Add("lilac", new Color(210, 175, 255));
    }

    public void Turn()
    {
        _light.intensity = _light.intensity > 0 ? 0 : 1;
    }

    public void ChangeColor(string value)
    {
        _light.color = colors[value];
    }
}
