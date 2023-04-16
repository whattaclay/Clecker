using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LvlUpButtonManager : MonoBehaviour
{
        
    [SerializeField] private Button lvlUpButton;
    [SerializeField] private BusinessConfig businessConfig;
    [SerializeField] private ProgressBarScript progressBar;
    [SerializeField] private TextMeshProUGUI currentProfit;
    [SerializeField] private BalanceConfig balanceConfig;
    private readonly float _progressPercentPerLvlUp = 10;
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

    public void ClickMultiplier()
    {
        if (!(balanceConfig.Balance.BalanceValue>= businessConfig.Values.LvlUpPrice)) return;
        balanceConfig.Balance.BalanceValue -= businessConfig.Values.LvlUpPrice;
        progressBar.FillValue(_progressPercentPerLvlUp);
        switch (businessConfig.Values.LvlOfBusiness)
        {
            case 0:
                businessConfig.Values.LvlUpPrice *= businessConfig.Values.NextLevelMultiplier;
                currentProfit.text = "Profit: " + businessConfig.Values.ProfitValue.ToString("0.0") + "$";
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
}