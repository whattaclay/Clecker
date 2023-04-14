using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Slider = UnityEngine.UI.Slider;

public class BusinessWindowManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _businessText;
    [SerializeField] private TextMeshProUGUI _progressPercentage;
    [SerializeField] private TextMeshProUGUI _currentLvl;
    [SerializeField] private TextMeshProUGUI _currentProfit;
    [SerializeField] private TextMeshProUGUI _lvlUpPriceText;
    [SerializeField] private TextMeshProUGUI _firstUpgradeText;
    [SerializeField] private TextMeshProUGUI _secondUpgradeText;
    [SerializeField] private TextMeshProUGUI _profitTimeText;
    [SerializeField] private TextMeshProUGUI _balance;
    [SerializeField] private Image _fillBar;
    private float _profitTimeVariable;
    [SerializeField] private BusinessConfig _businessConfig;
    
    private void Awake()
    {
        NameOFCanvasElements();
        _profitTimeVariable = _businessConfig.Values.ProfitTime;
        _profitTimeText.text = _businessConfig.Values.ProfitTime.ToString("0.0" + "s.");
        _fillBar.fillAmount = 0;
        
    }

    private void NameOFCanvasElements()
    {
        _businessText.text = _businessConfig.Values.BusinessName;
        _progressPercentage.text = _businessConfig.Values.ProgressPercentage+" %";
        
        _currentProfit.text = "Profit: " + _businessConfig.Values.ProfitValue;
        
        _firstUpgradeText.text = _businessConfig.Values.FirstUpgrdName + "\n" +
                                 _businessConfig.Values.FirstUpgrdPrice + "$";
        _secondUpgradeText.text = _businessConfig.Values.SecondUpgrdName + "\n" +
                                 _businessConfig.Values.SecondUpgrdPrice + "$";
        if (_businessConfig.Values.LvllUpButActivity)
        {
            _lvlUpPriceText.text = "Lvl Up \n Price: " + _businessConfig.Values.LvlUpPrice.ToString("0.00") + "$";
        }
    }

    private void Update()
    {
        ProfitBar();
        _balance.text ="Current account balance: " + _businessConfig.Values.Balance + "$";
        _currentLvl.text = "Lvl \n" + _businessConfig.Values.LvlOfBusiness;
    }

    private void ProfitBar()
    {
        _profitTimeVariable -= Time.deltaTime;
        _profitTimeText.text = _profitTimeVariable.ToString("0.0" + "s.");
        var normalizedValue = Mathf.Clamp(_profitTimeVariable / _businessConfig.Values.ProfitTime, 0.0f ,1.0f);
        _fillBar.fillAmount =(1- normalizedValue);
        if (_profitTimeVariable <= 0)
        {
            _businessConfig.Values.Balance += _businessConfig.Values.ProfitValue;
            _profitTimeVariable = _businessConfig.Values.ProfitTime;
        }
    }
    
}
