using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ProgressBarScript: MonoBehaviour
    {
        [SerializeField] private Image fillBar;
        [SerializeField] private TextMeshProUGUI percentageText;
        [SerializeField] private BusinessConfig businessConfig;
        
        private void Awake()
        {
            businessConfig.Values.progressPercentage = 0;
            switch (businessConfig.Values.lvlOfBusiness)
            {
                case 0: businessConfig.Values.progressPercentage += 0; break;
                case 1: businessConfig.Values.progressPercentage += 10; break;
                case 2: businessConfig.Values.progressPercentage += 20; break;
                case 3: businessConfig.Values.progressPercentage += 30; break;
                case 4: businessConfig.Values.progressPercentage += 40; break;
                case 5: businessConfig.Values.progressPercentage += 50; break;
            }

            if (!businessConfig.Values.firstUpgradeButActivity)
            {
                businessConfig.Values.progressPercentage += 25;
            }
            if (!businessConfig.Values.secondUpgradeButActivity)
            {
                businessConfig.Values.progressPercentage += 25;
            }
            fillBar.fillAmount = businessConfig.Values.progressPercentage / 100;
        }
        public void FillValue(float percent)
        {
            businessConfig.Values.progressPercentage += percent;
            fillBar.fillAmount =  businessConfig.Values.progressPercentage / 100;
            percentageText.text =  businessConfig.Values.progressPercentage + "%";
        }
    }
}