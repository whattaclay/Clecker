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
using ProgressBar = DefaultNamespace.ProgressBar;
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
    [SerializeField] private Image _fillBar;
    [SerializeField] private Image _disabledBusiness;
    private float _profitTimeVariable;
    [SerializeField] private BusinessConfig _businessConfig;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private BalanceConfig _balanceConfig;
    [SerializeField] private TextMeshProUGUI _balanceText;

    private void Awake()
    {
        _disabledBusiness.enabled = _businessConfig.Values.LvlOfBusiness == 0;
        CurrentProgressPercentage();
        NameOFCanvasElements();
        _profitTimeVariable = _businessConfig.Values.ProfitTime;
        _profitTimeText.text = _businessConfig.Values.ProfitTime.ToString("0.0" + "s.");
        _fillBar.fillAmount = 0;
    }

    private void CurrentProgressPercentage()
    {
        _businessConfig.Values.ProgressPercentage = 0;
        switch (_businessConfig.Values.LvlOfBusiness)
        {
            case 0: _businessConfig.Values.ProgressPercentage += 0; break;
            case 1: _businessConfig.Values.ProgressPercentage += 10; break;
            case 2: _businessConfig.Values.ProgressPercentage += 20; break;
            case 3: _businessConfig.Values.ProgressPercentage += 30; break;
            case 4: _businessConfig.Values.ProgressPercentage += 40; break;
            case 5: _businessConfig.Values.ProgressPercentage += 50; break;
        }

        if (!_businessConfig.Values.FirstUpgradeButActivity)
        {
            _businessConfig.Values.ProgressPercentage += 25;
        }
        if (!_businessConfig.Values.SecondUpgradeButActivity)
        {
            _businessConfig.Values.ProgressPercentage += 25;
        }
        progressBar.AwakeFillValue();
    }

    private void NameOFCanvasElements()
    {
        _currentLvl.text = "Lvl: \n" + _businessConfig.Values.LvlOfBusiness;
        _businessText.text = _businessConfig.Values.BusinessName + ":";
        _progressPercentage.text = _businessConfig.Values.ProgressPercentage+" %";
        
        _currentProfit.text = "Profit: " + _businessConfig.Values.ProfitValue.ToString("0.00") + "$";
        if (_businessConfig.Values.FirstUpgradeButActivity)
        {
            _firstUpgradeText.text = _businessConfig.Values.FirstUpgrdName +"+"+ 
                                     _businessConfig.Values.FirstUpgradePercentage + "%:" + "\n"+ 
                                     _businessConfig.Values.FirstUpgrdPrice + "$";
        }
        else
        {
            _firstUpgradeText.text = "Upgrade is Sold";
        }
        if (_businessConfig.Values.SecondUpgradeButActivity)
        {
            _secondUpgradeText.text = _businessConfig.Values.SecondUpgrdName +"+"+ 
                                      _businessConfig.Values.SecondUpgradePercentage + "%:" + "\n" + 
                                      _businessConfig.Values.SecondUpgrdPrice + "$";
        }
        else
        {
            _secondUpgradeText.text = "Upgrade is Sold";
        }
        if (_businessConfig.Values.LvllUpButActivity)
        {
            _lvlUpPriceText.text = "Lvl Up \n Price: " + _businessConfig.Values.LvlUpPrice.ToString("0.00") + "$";
        }
    }

    private void Update()
    {
        _balanceText.text ="Current account balance: " + _balanceConfig.Balance.BalanceValue.ToString("0.00") + "$";
        _currentLvl.text = "Lvl: \n" + _businessConfig.Values.LvlOfBusiness;
        if (_disabledBusiness.enabled == true)return;
        ProfitBar();
    }

    private void ProfitBar()
    {
        _profitTimeVariable -= Time.deltaTime;
        _profitTimeText.text = _profitTimeVariable.ToString("0.0" + "s.");
        var normalizedValue = Mathf.Clamp(_profitTimeVariable / _businessConfig.Values.ProfitTime, 0.0f ,1.0f);
        _fillBar.fillAmount =(1- normalizedValue);
        if (_profitTimeVariable <= 0)
        {
            _balanceConfig.Balance.BalanceValue += _businessConfig.Values.ProfitValue;
            _profitTimeVariable = _businessConfig.Values.ProfitTime;
        }
    }
    
}
