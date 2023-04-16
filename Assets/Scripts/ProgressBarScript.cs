using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScript: MonoBehaviour
{
    [SerializeField] private Image fillBar;
    [SerializeField] private TextMeshProUGUI percentageText;
    [SerializeField] private BusinessConfig businessConfig;
        
    private void Awake()
    {
        businessConfig.Values.ProgressPercentage = 0;
        switch (businessConfig.Values.LvlOfBusiness)
        {
            case 0: businessConfig.Values.ProgressPercentage += 0; break;
            case 1: businessConfig.Values.ProgressPercentage += 10; break;
            case 2: businessConfig.Values.ProgressPercentage += 20; break;
            case 3: businessConfig.Values.ProgressPercentage += 30; break;
            case 4: businessConfig.Values.ProgressPercentage += 40; break;
            case 5: businessConfig.Values.ProgressPercentage += 50; break;
        }

        if (!businessConfig.Values.FirstUpgradeButActivity)
        {
            businessConfig.Values.ProgressPercentage += 25;
        }
        if (!businessConfig.Values.SecondUpgradeButActivity)
        {
            businessConfig.Values.ProgressPercentage += 25;
        }
        fillBar.fillAmount = businessConfig.Values.ProgressPercentage / 100;
    }
    public void FillValue(float percent)
    {
        businessConfig.Values.ProgressPercentage += percent;
        fillBar.fillAmount =  businessConfig.Values.ProgressPercentage / 100;
        percentageText.text =  businessConfig.Values.ProgressPercentage + "%";
    }
}