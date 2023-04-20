using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game
{
    public class UpgradeButtonManager : MonoBehaviour
    {
        private const float ProgressPercentPerUpgrade = 25;
        [SerializeField] private Button firstUpgradeButton;
        [SerializeField] private Button secondUpgradeButton;
        [SerializeField] private BusinessConfig businessConfig;
        [SerializeField] private ProgressBarScript progressBar;
        [SerializeField] private BalanceConfig balanceConfig;
        [SerializeField] private UpgradeButtonView upgradeButtonView;
        private TextMeshProUGUI _firstButtonText;
        private TextMeshProUGUI _secondButtonText;

        private void Start()
        {
            _firstButtonText = firstUpgradeButton.GetComponentInChildren<TextMeshProUGUI>();
            _secondButtonText = secondUpgradeButton.GetComponentInChildren<TextMeshProUGUI>();
            secondUpgradeButton.interactable = businessConfig.Values.secondUpgradeButActivity;
            firstUpgradeButton.interactable = businessConfig.Values.firstUpgradeButActivity;
        }

        public void FirstUpgradeButtonState()
        {
            if (!(balanceConfig.Balance.balanceValue >= businessConfig.Values.firstUpgrdPrice)) return;
            balanceConfig.Balance.balanceValue -= businessConfig.Values.firstUpgrdPrice;
            businessConfig.Values.profitValue *= 1 + (businessConfig.Values.firstUpgradePercentage / 100);
            firstUpgradeButton.interactable = false;
            businessConfig.Values.firstUpgradeButActivity = false;
            progressBar.FillValue(ProgressPercentPerUpgrade);
            upgradeButtonView.OnUpgradeView(businessConfig.Values.firstUpgrdName);
            _firstButtonText.text = "Upgrade is Sold";
        }
        public void SecondUpgradeButtonState()
        {
            if (firstUpgradeButton.interactable) return;
            if (!(balanceConfig.Balance.balanceValue >= businessConfig.Values.secondUpgrdPrice)) return;
            balanceConfig.Balance.balanceValue -= businessConfig.Values.secondUpgrdPrice;
            businessConfig.Values.profitValue *= 1 + (businessConfig.Values.secondUpgradePercentage / 100);
            secondUpgradeButton.interactable = false;
            businessConfig.Values.secondUpgradeButActivity = false;
            progressBar.FillValue(ProgressPercentPerUpgrade);
            upgradeButtonView.OnUpgradeView(businessConfig.Values.secondUpgrdName);
            _secondButtonText.text = "Upgrade is Sold";
        }
    }
}