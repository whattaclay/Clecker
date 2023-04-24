using System;
using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Skins
{
    public class BuyUseButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private SkinsConfig skinConfig;
        [SerializeField] private BalanceConfig balance;
        [SerializeField] private TextMeshProUGUI skinNumberText;
        [SerializeField] private BusinessConfig[] businessConfigs;

        private int _skinNumber;
        

        private void Start()
        {
            _skinNumber = int.Parse(skinNumberText.text)-1;
            SetButtonText();
        }
        private void OnEnable()
        {
            SetButtonText();
        }
        private void Update()
        {//обновляет надпись на кнопке покупки/использования
            buttonText.text = skinConfig.SkinsScript[_skinNumber].buyButtonText;
        }

        public void OnClickBuyUseButton()
        {
            var config = skinConfig.SkinsScript[_skinNumber];
            
            CanBuyView();
            //если не куплено, выходит
            if (!config.buyState) return;
            //если скин уже используется, выходит
            if (config.useState) return;
            UseStateSwitcher();
            //меняет текст выбранной кнопки
            config.buyButtonText ="Is used!";
            //меняет скин кликера в каждом префабе бизнеса
            foreach (var businessConfig in businessConfigs)
            {
                businessConfig.Values.clickerSkin = config.skinImage;
            }
        }
        private void SetButtonText()
        {
            //если кнопка не куплена, то текст выводится (цена покупки + "$")
            if (!skinConfig.SkinsScript[_skinNumber].buyState)
            {
                skinConfig.SkinsScript[_skinNumber].buyButtonText = skinConfig.SkinsScript[_skinNumber].skinPrice + "$";
                return;
            }
            //если купленна, то проверяет используется ли, и выводит соответствующий текст
            skinConfig.SkinsScript[_skinNumber].buyButtonText = !skinConfig.SkinsScript[_skinNumber].useState ? "Use!" : "Is used!";
        }
        //проверка на способность купить скин
        private void CanBuyView()
        {
            var config = skinConfig.SkinsScript[_skinNumber];
            if (config.buyState) return;
            if (!(balance.Balance.balanceValue >= config.skinPrice)) return;
            balance.Balance.balanceValue -= config.skinPrice;
            config.buyState = true;
        }
        //меняет текст на всех купленных скинах на "использовать" и меняет UseState на false
        //а на выбранном скине на true
        private void UseStateSwitcher()
        {
            skinConfig.SkinsScript[_skinNumber].useState = true;
            for (int i = 0; i < skinConfig.SkinsScript.Length ; i++)
            {
                if(i == _skinNumber)continue;
                skinConfig.SkinsScript[i].useState = false;
                if (skinConfig.SkinsScript[i].buyState)
                {
                    skinConfig.SkinsScript[i].buyButtonText = "Use!";
                }
            }
        }
    }
}