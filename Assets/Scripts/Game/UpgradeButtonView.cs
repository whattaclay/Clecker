using Configs;
using TMPro;
using UnityEngine;

namespace Game
{
    public class UpgradeButtonView : MonoBehaviour
    {
        [SerializeField] private BusinessConfig businessConfig;
        [SerializeField] private TextMeshProUGUI businessText;
        [SerializeField] private TextMeshProUGUI currentProfit;
        
        public void OnUpgradeView(string upgradeName)
        {
            businessConfig.Values.businessName = upgradeName;
            businessText.text = upgradeName + ":";
            currentProfit.text = "Profit: " + businessConfig.Values.profitValue.ToString("0.0") + "$";
        }
    }
}