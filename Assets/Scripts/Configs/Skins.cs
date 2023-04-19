using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;


namespace Configs
{
    [Serializable]
    public class Skins 
    {
         public Sprite SkinImage;
         public string SkinName;
         public Button BuyButton;
         public string BuyButoonText;
         public int SkinPrice;
         public bool UseState;
    }
}