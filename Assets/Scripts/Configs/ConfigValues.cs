using System;
using UnityEngine.Serialization;

namespace DefaultNamespace
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
        public bool LvllUpButActivity;
        public bool FirstUpgradeButActivity;
        public bool SecondUpgradeButActivity;
        public float FirstUpgradePercentage;
        public float SecondUpgradePercentage;
    }
}