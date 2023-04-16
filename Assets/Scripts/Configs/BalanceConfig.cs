using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = nameof(BalanceConfig))]
    public class BalanceConfig: ScriptableObject
    {
        public Balance Balance => _balance;
        [SerializeField] private Balance _balance;
    }
}