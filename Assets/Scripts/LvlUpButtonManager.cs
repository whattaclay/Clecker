using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        if (businessConfig.Values.LvlOfBusiness !=5)
        {
            lvlUpButton.interactable = true;
            _butText.text = "Lvl Up \n Price: " + businessConfig.Values.LvlUpPrice.ToString("0.0") + "$";
        }
        else
        {
            _butText.text = "Max Level";
            lvlUpButton.interactable = false;
        }
    }
        public void LvlUpClick()
        {
            if (!(balanceConfig.Balance.BalanceValue>= businessConfig.Values.LvlUpPrice)) return;
            balanceConfig.Balance.BalanceValue -= businessConfig.Values.LvlUpPrice;
            progressBar.FillValue(ProgressPercentPerLvlUp);
            switch (businessConfig.Values.LvlOfBusiness)
            {
                case 0:
                    businessConfig.Values.LvlUpPrice *= businessConfig.Values.NextLevelMultiplier;
                    _butText.text = "Lvl Up \n Price: " + businessConfig.Values.LvlUpPrice.ToString("0.0")+ "$";
                    disabledBusiness.enabled = false;
                    businessConfig.Values.LvlOfBusiness++;
                    return;
                case 4:
                    businessConfig.Values.ProfitValue *= businessConfig.Values.NextLevelMultiplier;
                    currentProfit.text = "Profit: " + businessConfig.Values.ProfitValue.ToString("0.0") + "$";
                    _butText.text = "Max Level";
                    lvlUpButton.interactable = false;
                    businessConfig.Values.LvlOfBusiness++;
                    return;
            }

            businessConfig.Values.LvlUpPrice *= businessConfig.Values.NextLevelMultiplier;
            businessConfig.Values.ProfitValue *= businessConfig.Values.NextLevelMultiplier;
            currentProfit.text = "Profit: " + businessConfig.Values.ProfitValue.ToString("0.0") + "$";
            _butText.text = "Lvl Up \n Price: " + businessConfig.Values.LvlUpPrice.ToString("0.0") + "$";
            businessConfig.Values.LvlOfBusiness++;
        }
    //то же, только на каждое значение
    /*public void LvlUpClick()
    {
        if (!(balanceConfig.Balance.BalanceValue>= businessConfig.Values.LvlUpPrice)) return;
        balanceConfig.Balance.BalanceValue -= businessConfig.Values.LvlUpPrice;
        progressBar.FillValue(_progressPercentPerLvlUp);
        switch (businessConfig.Values.LvlOfBusiness)
        {
            case 0:
                businessConfig.Values.LvlUpPrice *= businessConfig.Values.NextLevelMultiplier;
                _butText.text = "Lvl Up \n Price: " + businessConfig.Values.LvlUpPrice.ToString("0.0")+ "$";
                disabledBusiness.enabled = false;
                break;
            case 1:
                businessConfig.Values.LvlUpPrice *= businessConfig.Values.NextLevelMultiplier;
                businessConfig.Values.ProfitValue *= businessConfig.Values.NextLevelMultiplier;
                currentProfit.text = "Profit: " + businessConfig.Values.ProfitValue.ToString("0.0") + "$";
                _butText.text = "Lvl Up \n Price: " + businessConfig.Values.LvlUpPrice.ToString("0.0") + "$";
                break;
            case 2:
                businessConfig.Values.LvlUpPrice *= businessConfig.Values.NextLevelMultiplier;
                businessConfig.Values.ProfitValue *= businessConfig.Values.NextLevelMultiplier;
                currentProfit.text = "Profit: " + businessConfig.Values.ProfitValue.ToString("0.0") + "$";
                _butText.text = "Lvl Up \n Price: " + businessConfig.Values.LvlUpPrice.ToString("0.0") + "$";
                break;
            case 3:
                businessConfig.Values.LvlUpPrice *= businessConfig.Values.NextLevelMultiplier;
                businessConfig.Values.ProfitValue *= businessConfig.Values.NextLevelMultiplier;
                currentProfit.text = "Profit: " + businessConfig.Values.ProfitValue.ToString("0.0") + "$";
                _butText.text = "Lvl Up \n Price: " + businessConfig.Values.LvlUpPrice.ToString("0.0") + "$";
                break;
            case 4:
                businessConfig.Values.ProfitValue *= businessConfig.Values.NextLevelMultiplier;
                currentProfit.text = "Profit: " + businessConfig.Values.ProfitValue.ToString("0.0") + "$";
                _butText.text = "Max Level";
                lvlUpButton.interactable = false;
                break;
        }
        businessConfig.Values.LvlOfBusiness++;
    }
        */

    
}