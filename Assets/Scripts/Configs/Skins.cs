using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;


namespace Configs
{
    [Serializable]
    public class Skins 
    {
          public Sprite skinImage;
          public string skinName;
          public string buyButtonText;
          public int skinPrice;
          public bool useState;
          public bool buyState;
    }
}