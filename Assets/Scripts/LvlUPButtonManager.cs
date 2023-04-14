using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace
{
    
    public class LvlUPButtonManager : MonoBehaviour
    {
        
        [SerializeField] private Button _lvlUpButton;
        [SerializeField] private BusinessConfig _businessConfig;
        [SerializeField] private ProgressBar progressBar;
        [SerializeField] private TextMeshProUGUI _currentProfit;
        [SerializeField] private BalanceConfig _balanceConfig;
        
        private readonly float _progressPercentPerLvlUp = 10;
        [SerializeField] private Image _disabledBusiness;

        private void Awake()
        {
            if (_businessConfig.Values.LvlOfBusiness !=5)
            {
                _businessConfig.Values.LvllUpButActivity = true;
            }
            else
            {
                _lvlUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Max Level";
                _lvlUpButton.interactable = false;
            }
        }

        public void ClickMultiplier()
        {
            switch (_businessConfig.Values.LvlOfBusiness)
            {
                case 0:
                    if (!(_balanceConfig.Balance.BalanceValue>= _businessConfig.Values.LvlUpPrice)) return;
                    _balanceConfig.Balance.BalanceValue -= _businessConfig.Values.LvlUpPrice;
                    _businessConfig.Values.LvlUpPrice *= _businessConfig.Values.NextLevelMultiplier;
                    _currentProfit.text = "Profit: " + _businessConfig.Values.ProfitValue.ToString("0.00") + "$";
                    _lvlUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Lvl Up \n Price: " +
                        _businessConfig.Values.LvlUpPrice.ToString("0.00")+ "$";
                    progressBar.FillValue(_progressPercentPerLvlUp);
                    _businessConfig.Values.LvlOfBusiness++;
                    _disabledBusiness.enabled = false;
                    break;
                case 1:
                    if (!(_balanceConfig.Balance.BalanceValue >= _businessConfig.Values.LvlUpPrice)) return;
                    _balanceConfig.Balance.BalanceValue -= _businessConfig.Values.LvlUpPrice;
                    _businessConfig.Values.LvlUpPrice *= _businessConfig.Values.NextLevelMultiplier;
                    _businessConfig.Values.ProfitValue *= _businessConfig.Values.NextLevelMultiplier;
                    _currentProfit.text = "Profit: " + _businessConfig.Values.ProfitValue.ToString("0.00") + "$";
                    _lvlUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Lvl Up \n Price: " +
                        _businessConfig.Values.LvlUpPrice.ToString("0.00") + "$";
                    progressBar.FillValue(_progressPercentPerLvlUp);
                    _businessConfig.Values.LvlOfBusiness++;
                    break;
                case 2:
                    if (!(_balanceConfig.Balance.BalanceValue >= _businessConfig.Values.LvlUpPrice)) return;
                    _balanceConfig.Balance.BalanceValue -= _businessConfig.Values.LvlUpPrice;
                    _businessConfig.Values.LvlUpPrice *= _businessConfig.Values.NextLevelMultiplier;
                    _businessConfig.Values.ProfitValue *= _businessConfig.Values.NextLevelMultiplier;
                    _currentProfit.text = "Profit: " + _businessConfig.Values.ProfitValue.ToString("0.00") + "$";
                    _lvlUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Lvl Up \n Price: " +
                        _businessConfig.Values.LvlUpPrice.ToString("0.00") + "$";
                    progressBar.FillValue(_progressPercentPerLvlUp);
                    _businessConfig.Values.LvlOfBusiness++;
                    
                    break;
                case 3:
                    if (!(_balanceConfig.Balance.BalanceValue >= _businessConfig.Values.LvlUpPrice)) return;
                    _balanceConfig.Balance.BalanceValue -= _businessConfig.Values.LvlUpPrice;
                    _businessConfig.Values.LvlUpPrice *= _businessConfig.Values.NextLevelMultiplier;
                    _businessConfig.Values.ProfitValue *= _businessConfig.Values.NextLevelMultiplier;
                    _currentProfit.text = "Profit: " + _businessConfig.Values.ProfitValue.ToString("0.00") + "$";
                    _lvlUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Lvl Up \n Price: " +
                        _businessConfig.Values.LvlUpPrice.ToString("0.00") + "$";
                    progressBar.FillValue(_progressPercentPerLvlUp);
                    _businessConfig.Values.LvlOfBusiness++;
                    break;
                case 4:
                    if (!(_balanceConfig.Balance.BalanceValue >= _businessConfig.Values.LvlUpPrice)) return;
                    _balanceConfig.Balance.BalanceValue -= _businessConfig.Values.LvlUpPrice;
                    _businessConfig.Values.ProfitValue *= _businessConfig.Values.NextLevelMultiplier;
                    _currentProfit.text = "Profit: " + _businessConfig.Values.ProfitValue.ToString("0.00") + "$";
                    _lvlUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Max Level";
                    progressBar.FillValue(_progressPercentPerLvlUp);
                    _businessConfig.Values.LvlOfBusiness++;
                    _lvlUpButton.interactable = false;
                    _businessConfig.Values.LvllUpButActivity = false;
                    break;
            }
        }
    }
}