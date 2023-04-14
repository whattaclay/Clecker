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

        public void FillValue(float percent)
        {
            _businessConfig.Values.ProgressPercentage += percent;
            _fillBar.fillAmount =  _businessConfig.Values.ProgressPercentage / 100;
            _percentageText.text =  _businessConfig.Values.ProgressPercentage + "%";
        }

        public void AwakeFillValue()
        {
            _fillBar.fillAmount =  _businessConfig.Values.ProgressPercentage / 100;
        }
    }
}