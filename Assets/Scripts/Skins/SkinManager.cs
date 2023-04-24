using System;
using Configs;
using UnityEngine;
using UnityEngine.Serialization;

namespace Skins
{
    public class SkinManager : MonoBehaviour
    {   
        [SerializeField] private SkinsConfig skinsConfig;
        [SerializeField] private SkinAreaView skinPrefab;
        [SerializeField] private RectTransform content;
        //создает префабы скинов(кол-во задается в конфиге)
        private void Awake()
        {
            int skinsLength = skinsConfig.SkinsScript.Length;
            for (int i = 0; i < skinsLength; i++)
            {
                var skinInstance = Instantiate(skinPrefab, content);
                skinInstance.SkinAreaInstance(i);
            }
        }
    }
}