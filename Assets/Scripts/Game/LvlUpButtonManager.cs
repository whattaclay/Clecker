using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class LvlUpButtonManager : MonoBehaviour
    {
        
        private const float ProgressPercentPerLvlUp = 10;
        [SerializeField] private Button lvlUpButton;
        [SerializeField] private BusinessConfig businessConfig;
        [SerializeField] private ProgressBarScript progressBar;
        [SerializeField] private TextMeshProUGUI currentProfit;
        [SerializeField] private BalanceConfig balanceConfig;
        [SerializeField] private Image disabledBusiness;
        private TextMeshProUGUI _butText;

        private void Awake()
        {
            _butText = lvlUpButton.GetComponentInChildren<TextMeshProUGUI>();
            if (businessConfig.Values.lvlOfBusiness !=5)
            {
                lvlUpButton.interactable = true;
                _butText.text = "Lvl Up \n Price: " + businessConfig.Values.lvlUpPrice.ToString("0.0") + "$";
            }
            else
            {
                _butText.text = "Max Level";
                lvlUpButton.interactable = false;
            }
        }
        public void LvlUpClick()
        {
            if (!(balanceConfig.Balance.balanceValue>= businessConfig.Values.lvlUpPrice)) return;
            balanceConfig.Balance.balanceValue -= businessConfig.Values.lvlUpPrice;
            progressBar.FillValue(ProgressPercentPerLvlUp);
            switch (businessConfig.Values.lvlOfBusiness)
            {
                case 0:
                    businessConfig.Values.lvlUpPrice *= businessConfig.Values.nextLevelMultiplier;
                    _butText.text = "Lvl Up \n Price: " + businessConfig.Values.lvlUpPrice.ToString("0.0")+ "$";
                    disabledBusiness.enabled = false;
                    businessConfig.Values.lvlOfBusiness++;
                    return;
                case 4:
                    businessConfig.Values.profitValue *= businessConfig.Values.nextLevelMultiplier;
                    currentProfit.text = "Profit: " + businessConfig.Values.profitValue.ToString("0.0") + "$";
                    _butText.text = "Max Level";
                    lvlUpButton.interactable = false;
                    businessConfig.Values.lvlOfBusiness++;
                    return;
            }

            businessConfig.Values.lvlUpPrice *= businessConfig.Values.nextLevelMultiplier;
            businessConfig.Values.profitValue *= businessConfig.Values.nextLevelMultiplier;
            currentProfit.text = "Profit: " + businessConfig.Values.profitValue.ToString("0.0") + "$";
            _butText.text = "Lvl Up \n Price: " + businessConfig.Values.lvlUpPrice.ToString("0.0") + "$";
            businessConfig.Values.lvlOfBusiness++;
        }
    }
}