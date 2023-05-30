using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    public class ChangeColorItem : MonoBehaviour
    {
        [SerializeField] private Color color = new Color(1, 1, 1);
        [SerializeField] private string colorName = "white";
        [SerializeField] private Light light;

        public void ChangeColor()
        {
            light.color = color;
        }
    }
}
