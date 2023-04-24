using Configs;
using UnityEngine;

namespace Game
{
    public class Clicker: MonoBehaviour
    {
        [SerializeField] private BusinessConfig businessConfig;
        [SerializeField] private BalanceConfig balanceConfig;
        public void ByClick()
        {
            balanceConfig.Balance.balanceValue += businessConfig.Values.profitValue / 30;
        }
    }
}