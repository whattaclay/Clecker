using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI businessText;
    [SerializeField] private Button firstUpgradeButton;
    [SerializeField] private Button secondUpgradeButton;
    [SerializeField] private BusinessConfig businessConfig;
    private TextMeshProUGUI _firstButtonText;
    private TextMeshProUGUI _secondButtonText;
    [SerializeField] private ProgressBarScript progressBar;
    private readonly float _progressPercentPerUpgrade = 25;
    [SerializeField] private TextMeshProUGUI currentProfit;
    [SerializeField] private BalanceConfig balanceConfig;

    private void Start()
    {
        _firstButtonText = firstUpgradeButton.GetComponentInChildren<TextMeshProUGUI>();
        _secondButtonText = secondUpgradeButton.GetComponentInChildren<TextMeshProUGUI>();
        secondUpgradeButton.interactable = businessConfig.Values.SecondUpgradeButActivity;
        firstUpgradeButton.interactable = businessConfig.Values.FirstUpgradeButActivity;
    }

    public void FirstUpgradeButtonState()
    {
        if (!(balanceConfig.Balance.BalanceValue >= businessConfig.Values.FirstUpgrdPrice)) return;
        balanceConfig.Balance.BalanceValue -= businessConfig.Values.FirstUpgrdPrice;
        businessText.text = businessConfig.Values.FirstUpgrdName + ":";
        businessConfig.Values.BusinessName = businessConfig.Values.FirstUpgrdName;
        businessConfig.Values.ProfitValue *= 1 + (businessConfig.Values.FirstUpgradePercentage / 100);
        currentProfit.text = "Profit: " + businessConfig.Values.ProfitValue.ToString("0.0") + "$";
        _firstButtonText.text = "Upgrade is Sold";
        firstUpgradeButton.interactable = false;
        businessConfig.Values.FirstUpgradeButActivity = false;
        progressBar.FillValue(_progressPercentPerUpgrade);
    }
    public void SecondUpgradeButtonState()
    {
        if (firstUpgradeButton.interactable) return;
        if (!(balanceConfig.Balance.BalanceValue >= businessConfig.Values.SecondUpgrdPrice)) return;
        balanceConfig.Balance.BalanceValue -= businessConfig.Values.SecondUpgrdPrice;
        businessText.text = businessConfig.Values.SecondUpgrdName + ":";
        businessConfig.Values.BusinessName = businessConfig.Values.SecondUpgrdName;
        businessConfig.Values.ProfitValue *= 1 + (businessConfig.Values.SecondUpgradePercentage / 100);
        currentProfit.text = "Profit: " + businessConfig.Values.ProfitValue.ToString("0.0") + "$";
        _secondButtonText.text = "Upgrade is Sold";
        secondUpgradeButton.interactable = false;
        businessConfig.Values.SecondUpgradeButActivity = false;
        progressBar.FillValue(_progressPercentPerUpgrade);
    }
}