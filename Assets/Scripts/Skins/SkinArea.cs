using Configs;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

namespace Skins
{
    public class SkinArea : MonoBehaviour 
    {
        [SerializeField] private TextMeshProUGUI _skinNameText;
        [SerializeField] private Image _skinImage;
        [SerializeField] private SkinsConfig _skinsConfig;
        [SerializeField] private TextMeshProUGUI _skinNumber;

        public void SkinAreaInstance(int skinNumber)
        {
            _skinNumber.text = (skinNumber+1).ToString();
            var skinConfig = _skinsConfig.SkinsScript[skinNumber];
            _skinImage.sprite = skinConfig.SkinImage;
            _skinNameText.text = skinConfig.SkinName;
        }
    }
}