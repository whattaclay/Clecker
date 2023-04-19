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
                [SerializeField] private TextMeshProUGUI _buyButtonText;
                [SerializeField] private SkinsConfig _skinsConfig;

                public void SkinAreaInstance(int skinNumber)
                {
                        var skinConfig = _skinsConfig.SkinsScript[skinNumber];
                        _skinImage.sprite = skinConfig.SkinImage;
                        _buyButtonText.text = skinConfig.BuyButoonText;
                        _skinNameText.text = skinConfig.SkinName;
                }
        }
}