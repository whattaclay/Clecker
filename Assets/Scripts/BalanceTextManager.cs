using System;
using Configs;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class BalanceTextManager: MonoBehaviour
    {
        [SerializeField] private BalanceConfig balance;
        [SerializeField] private TextMeshProUGUI balanceText;

        private void Update()
        {
            balanceText.text ="Current account balance: " + balance.Balance.BalanceValue.ToString("0.0") + "$";
        }
    }
}