using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UpgradeButtonManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _businessText;
        [SerializeField] private Button _firstUpgradeButton;
        [SerializeField] private Button _secondUpgradeButton;
        [SerializeField] private BusinessConfig _businessConfig;
        private TextMeshProUGUI _firstButtonText;
        private TextMeshProUGUI _secondButtonText;
        [SerializeField]private ProgressBar progressBar;
        private float _progressPercentPerUpgrade = 25;
        [SerializeField] private TextMeshProUGUI _currentProfit;

        private void Start()
        {
            _firstButtonText = _firstUpgradeButton.GetComponentInChildren<TextMeshProUGUI>();
            _secondButtonText = _secondUpgradeButton.GetComponentInChildren<TextMeshProUGUI>();
            _secondUpgradeButton.interactable = _businessConfig.Values.SecondUpgradeButActivity;
            _firstUpgradeButton.interactable = _businessConfig.Values.FirstUpgradeButActivity;
        }

        public void FirstUpgradeButtonState()
        {
            if (_businessText.text!= _businessConfig.Values.SecondUpgrdName)
            {
                _businessText.text = _businessConfig.Values.FirstUpgrdName + ":";
                _businessConfig.Values.BusinessName = _businessConfig.Values.FirstUpgrdName + ":";
            }
            _businessConfig.Values.ProfitValue *= 1+(_businessConfig.Values.FirstUpgradePricePercentage/ 100);
            _currentProfit.text = "Profit: " + _businessConfig.Values.ProfitValue.ToString("0.00") + "$";
            _firstButtonText.text = "Upgrade is Sold";
            _firstUpgradeButton.interactable = false;
            _businessConfig.Values.FirstUpgradeButActivity = false;
            progressBar.FillValue(_progressPercentPerUpgrade);
        }
        public void SecondUpgradeButtonState()
        {
            if (_firstUpgradeButton.interactable)return;
            _businessText.text = _businessConfig.Values.SecondUpgrdName + ":";
            _businessConfig.Values.BusinessName = _businessConfig.Values.SecondUpgrdName + ":";
            _businessConfig.Values.ProfitValue *= 1+(_businessConfig.Values.SecondUpgradePricePercentage/ 100);
            _currentProfit.text = "Profit: " + _businessConfig.Values.ProfitValue.ToString("0.00") + "$";
            _secondButtonText.text = "Upgrade is Sold";
            _secondUpgradeButton.interactable = false;
            _businessConfig.Values.SecondUpgradeButActivity = false;
            progressBar.FillValue(_progressPercentPerUpgrade);
        } 
    }
}