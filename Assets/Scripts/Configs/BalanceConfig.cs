using UnityEditor.U2D.Path;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = nameof(BalanceConfig))]
    public class BalanceConfig: ScriptableObject
    {
        public Balance Balance => _balance;
        [SerializeField] private Balance _balance;
    }
}