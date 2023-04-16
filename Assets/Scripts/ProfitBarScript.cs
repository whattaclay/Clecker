using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfitBarScript : MonoBehaviour
{
    [SerializeField] private Image fillBar;
    [SerializeField] private BalanceConfig balanceConfig;
    [SerializeField] private TextMeshProUGUI profitTimeText;
    private float _profitTimeVariable = 0f;
        

    public void ProfitBar(float profitTime, float profitValue)
    {
        _profitTimeVariable -= Time.deltaTime;
        profitTimeText.text = _profitTimeVariable.ToString("0.0" + "s.");
        var normalizedValue = Mathf.Clamp(_profitTimeVariable / profitTime, 0.0f, 1.0f);
        fillBar.fillAmount = (1 - normalizedValue);
        if (_profitTimeVariable <= 0)
        {
            balanceConfig.Balance.BalanceValue += profitValue;
            _profitTimeVariable = profitTime;
        }
    }
}