using System;
using UnityEngine;

namespace Configs
{
    [Serializable]
    public class ConfigValues
    {
        public int LvlOfBusiness;
        public float ProfitValue;
        public float LvlUpPrice;
        public int FirstUpgrdPrice;
        public string FirstUpgrdName;
        public int SecondUpgrdPrice;
        public string SecondUpgrdName;
        public float ProgressPercentage;
        public float ProfitTime;
        public string BusinessName;
        public float NextLevelMultiplier;
        public bool FirstUpgradeButActivity;
        public bool SecondUpgradeButActivity;
        public float FirstUpgradePercentage;
        public float SecondUpgradePercentage;
        public Sprite ClickerSkin;
    }
}