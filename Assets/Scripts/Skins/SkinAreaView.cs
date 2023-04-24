using Configs;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

namespace Skins
{
    public class SkinAreaView : MonoBehaviour 
    {
        [SerializeField] private TextMeshProUGUI skinNameText;
        [SerializeField] private Image skinImage;
        [SerializeField] private SkinsConfig skinsConfig;
        [SerializeField] private TextMeshProUGUI skinNumber;

        //устанавливает параметры скина из префаба
        public void SkinAreaInstance(int skinNumberMain)
        {
            skinNumber.text = (skinNumberMain+1).ToString();
            var skinConfig = skinsConfig.SkinsScript[skinNumberMain];
            skinImage.sprite = skinConfig.skinImage;
            skinNameText.text = skinConfig.skinName;
        }
    }
}