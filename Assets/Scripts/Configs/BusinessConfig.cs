using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = nameof(BusinessConfig))]
    public class BusinessConfig : ScriptableObject
    {
        public ConfigValues Values => _values;
        [SerializeField] private ConfigValues _values;
    }
}