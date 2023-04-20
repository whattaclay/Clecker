using System;
using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Skins
{
    // todo разнести этот огромный класс по логике
    
    public class BuyUseButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private SkinsConfig skinConfig;
        [SerializeField] private BalanceConfig balance;
        [SerializeField] private TextMeshProUGUI skinNumberText;
        [SerializeField] private BusinessConfig[] businessConfigs;

        private int _skinNumber;
        private void Start()
        {
            _skinNumber = int.Parse(skinNumberText.text)-1;
            if (!skinConfig.SkinsScript[_skinNumber].BuyState)
            {
                skinConfig.SkinsScript[_skinNumber].BuyButoonText = skinConfig.SkinsScript[_skinNumber].SkinPrice + "$";
                return;
            }
            skinConfig.SkinsScript[_skinNumber].BuyButoonText = !skinConfig.SkinsScript[_skinNumber].UseState ? "Use!" : "Is used!";
        }

        private void Update()
        {
            button.GetComponentInChildren<TextMeshProUGUI>().text = skinConfig.SkinsScript[_skinNumber].BuyButoonText ;
        }

        public void OnClickBuyUseButton()
        {
            var _skinConfig = skinConfig.SkinsScript[_skinNumber];
            
            CanBuyView();
            if (!_skinConfig.BuyState) return;
            if (_skinConfig.UseState) return;
            UseStateSwitcher();
            _skinConfig.BuyButoonText ="Is used!";
            foreach (var businessConfig in businessConfigs)
            {
                businessConfig.Values.ClickerSkin = _skinConfig.SkinImage;
            }
        }

        private void CanBuyView()
        {
            var _skinConfig = skinConfig.SkinsScript[_skinNumber];
            if (_skinConfig.BuyState) return;
            if (!(balance.Balance.BalanceValue >= _skinConfig.SkinPrice)) return;
            balance.Balance.BalanceValue -= _skinConfig.SkinPrice;
            _skinConfig.BuyState = true;
        }
        private void UseStateSwitcher()
        {
            skinConfig.SkinsScript[_skinNumber].UseState = true;
            for (int i = 0; i < skinConfig.SkinsScript.Length ; i++)
            {
                if(i == _skinNumber)continue;
                skinConfig.SkinsScript[i].UseState = false;
                if (skinConfig.SkinsScript[i].BuyState)
                {
                    skinConfig.SkinsScript[i].BuyButoonText = "Use!";
                }
            }
        }
    }
}