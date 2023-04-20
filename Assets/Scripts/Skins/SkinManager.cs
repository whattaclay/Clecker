using System;
using Configs;
using UnityEngine;

namespace Skins
{
    public class SkinManager : MonoBehaviour
    {   
        [SerializeField] private SkinsConfig _skinsConfig;
        [SerializeField] private SkinArea _skinPrefab;
        [SerializeField] private RectTransform _content;
        private void Awake()
        {
            int skinsLength = _skinsConfig.SkinsScript.Length;
            for (int i = 0; i < skinsLength; i++)
            {
                var skinInstance = Instantiate(_skinPrefab, _content);
                skinInstance.SkinAreaInstance(i);
            }
        }
    }
}