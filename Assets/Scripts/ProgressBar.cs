using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ProgressBar: MonoBehaviour
    {
        [SerializeField] private Image _fillBar;
        [SerializeField] private TextMeshProUGUI _percentageText;
        [SerializeField] private BusinessConfig _businessConfig;
        
        private void Awake()
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
            _fillBar.fillAmount =  _businessConfig.Values.ProgressPercentage / 100;
        }
        public void FillValue(float percent)
        {
            _businessConfig.Values.ProgressPercentage += percent;
            _fillBar.fillAmount =  _businessConfig.Values.ProgressPercentage / 100;
            _percentageText.text =  _businessConfig.Values.ProgressPercentage + "%";
        }
    }
}
