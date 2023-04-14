using System;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    [Serializable]
    public class ConfigValues
    {
        public float Balance;
        public int LvlOfBusiness;
        public float ProfitValue;
        public float LvlUpPrice;
        public int FirstUpgrdPrice;
        public string FirstUpgrdName;
        public int SecondUpgrdPrice;
        public string SecondUpgrdName;
        public int ProgressPercentage;
        public float ProfitTime;
        public string BusinessName;
        public float NextLevelMultiplier;
        public bool LvllUpButActivity;
    }
}