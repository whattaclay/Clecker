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
    [SerializeField] private Image _disabledBusiness;
    [SerializeField] private BusinessConfig _businessConfig;
    [SerializeField] private BalanceConfig _balanceConfig;
    [SerializeField] private TextMeshProUGUI _balanceText;
    [SerializeField] ProfitBarScript _profitBar;

    private void Awake()
    {
        _disabledBusiness.enabled = _businessConfig.Values.LvlOfBusiness == 0;
        NameOFCanvasElements();
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
        _profitBar.ProfitBar(_businessConfig.Values.ProfitTime, _businessConfig.Values.ProfitValue);
    }
}
