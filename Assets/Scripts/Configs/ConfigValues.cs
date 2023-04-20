using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Configs
{
    [Serializable]
    public class ConfigValues
    {
        public int lvlOfBusiness;
        public float profitValue;
        public float lvlUpPrice;
        public int firstUpgrdPrice;
        public string firstUpgrdName;
        public int secondUpgrdPrice;
        public string secondUpgrdName;
        public float progressPercentage;
        public float profitTime;
        public string businessName;
        public float nextLevelMultiplier;
        public bool firstUpgradeButActivity;
        public bool secondUpgradeButActivity;
        public float firstUpgradePercentage;
        public float secondUpgradePercentage;
        public Sprite clickerSkin;
    }
}