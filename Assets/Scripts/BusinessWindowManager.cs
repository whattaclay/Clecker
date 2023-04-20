using Configs;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class BusinessWindowManager : MonoBehaviour
{
     [SerializeField] private TextMeshProUGUI businessText;
     [SerializeField] private TextMeshProUGUI progressPercentage;
     [SerializeField] private TextMeshProUGUI currentLvl;
     [SerializeField] private TextMeshProUGUI currentProfit;
     [SerializeField] private TextMeshProUGUI firstUpgradeText;
     [SerializeField] private TextMeshProUGUI secondUpgradeText;
     [SerializeField] private Image disabledBusiness;
     [SerializeField] private BusinessConfig businessConfig;
     [SerializeField] private ProfitBarScript profitBar;
     [SerializeField] private Image clickerImage;

    private void Awake()
    {
        disabledBusiness.enabled = businessConfig.Values.LvlOfBusiness == 0;
        NameOfCanvasElements();
    }
    private void NameOfCanvasElements()
    {
        currentLvl.text = "Lvl: \n" + businessConfig.Values.LvlOfBusiness;
        businessText.text = businessConfig.Values.BusinessName + ":";
        progressPercentage.text = businessConfig.Values.ProgressPercentage+" %";
        
        currentProfit.text = "Profit: " + businessConfig.Values.ProfitValue.ToString("0.0") + "$";
        if (businessConfig.Values.FirstUpgradeButActivity)
        {
            firstUpgradeText.text = businessConfig.Values.FirstUpgrdName +"+"+ 
                                     businessConfig.Values.FirstUpgradePercentage + "%:" + "\n"+ 
                                     businessConfig.Values.FirstUpgrdPrice + "$";
        }
        else
        {
            firstUpgradeText.text = "Upgrade is Sold";
        }
        if (businessConfig.Values.SecondUpgradeButActivity)
        {
            secondUpgradeText.text = businessConfig.Values.SecondUpgrdName +"+"+ 
                                      businessConfig.Values.SecondUpgradePercentage + "%:" + "\n" + 
                                      businessConfig.Values.SecondUpgrdPrice + "$";
        }
        else
        {
            secondUpgradeText.text = "Upgrade is Sold";
        }
    }
    private void Update()
    {
        clickerImage.sprite = businessConfig.Values.ClickerSkin;
        currentLvl.text = "Lvl: \n" + businessConfig.Values.LvlOfBusiness;
        if (disabledBusiness.enabled == true)return;
        profitBar.ProfitBar(businessConfig.Values.ProfitTime, businessConfig.Values.ProfitValue);
    }
}