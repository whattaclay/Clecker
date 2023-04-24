using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = nameof(SkinsConfig))]
    public class SkinsConfig : ScriptableObject
    {
        public Skins[] SkinsScript => _skins;
        [SerializeField] private Skins[] _skins;
    }
}