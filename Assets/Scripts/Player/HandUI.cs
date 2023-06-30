using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    [RequireComponent(typeof(RectTransform))]
    public class HandUI : MonoBehaviour
    {
        [SerializeField] RawImage _image;
        [Space]
        [SerializeField] Texture _default;
        [SerializeField] Texture _grab, _door, _button;

        public void SetTexture(Interactor.HandMode hand)
        {
            switch (hand)
            {
                case Interactor.HandMode.canUse:
                    if (_image.texture != _default) _image.texture = _default;
                    break;
                case Interactor.HandMode.grab:
                    if (_image.texture != _grab) _image.texture = _grab;
                    break;
                case Interactor.HandMode.door:
                    if (_image.texture != _door) _image.texture = _door;
                    break;
                case Interactor.HandMode.button:
                    if (_image.texture != _button) _image.texture = _button;
                    break;
                default:
                    if (_image.texture != _default) _image.texture = _default;
                    break;
            }
        }

        public void SetAlpha(float a)
        {
            a = Mathf.Clamp01(a);
            Color c = _image.color;
            _image.color = new Color(c.r, c.g, c.b, a);
        }

        public void SetEnableImage(bool state)
        {
            if (_image.enabled != state) _image.enabled = state;
        }
    }
}
