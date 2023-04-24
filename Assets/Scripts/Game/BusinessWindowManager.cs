using Configs;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Game
{
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
            disabledBusiness.enabled = businessConfig.Values.lvlOfBusiness == 0;
            NameOfCanvasElements();
        }
        private void NameOfCanvasElements()
        {
            currentLvl.text = "Lvl: \n" + businessConfig.Values.lvlOfBusiness;
            businessText.text = businessConfig.Values.businessName + ":";
            progressPercentage.text = businessConfig.Values.progressPercentage+" %";
        
            currentProfit.text = "Profit: " + businessConfig.Values.profitValue.ToString("0.0") + "$";
            if (businessConfig.Values.firstUpgradeButActivity)
            {
                firstUpgradeText.text = businessConfig.Values.firstUpgrdName +"+"+ 
                                        businessConfig.Values.firstUpgradePercentage + "%:" + "\n"+ 
                                        businessConfig.Values.firstUpgrdPrice + "$";
            }
            else
            {
                firstUpgradeText.text = "Upgrade is Sold";
            }
            if (businessConfig.Values.secondUpgradeButActivity)
            {
                secondUpgradeText.text = businessConfig.Values.secondUpgrdName +"+"+ 
                                         businessConfig.Values.secondUpgradePercentage + "%:" + "\n" + 
                                         businessConfig.Values.secondUpgrdPrice + "$";
            }
            else
            {
                secondUpgradeText.text = "Upgrade is Sold";
            }
        }
        private void Update()
        {
            clickerImage.sprite = businessConfig.Values.clickerSkin;
            currentLvl.text = "Lvl: \n" + businessConfig.Values.lvlOfBusiness;
            if (disabledBusiness.enabled == true)return;
            profitBar.ProfitBar(businessConfig.Values.profitTime, businessConfig.Values.profitValue);
        }
    }
}