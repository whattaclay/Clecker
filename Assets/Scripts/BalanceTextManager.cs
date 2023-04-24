using Configs;
using TMPro;
using UnityEngine;

public class BalanceTextManager: MonoBehaviour
{
    [SerializeField] private BalanceConfig balance;
    [SerializeField] private TextMeshProUGUI balanceText;

    private void Update()
    {
        balanceText.text ="Current account balance: " + balance.Balance.balanceValue.ToString("0.0") + "$";
    }
}