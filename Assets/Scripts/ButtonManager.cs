using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    
    public class ButtonManager : MonoBehaviour
    {
        
        [SerializeField] private Button _lvlUpButton;
        [SerializeField] private BusinessConfig _businessConfig;

        private void Start()
        {
            if (!_businessConfig.Values.LvllUpButActivity)
            {
                _lvlUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Max Level";
                _lvlUpButton.interactable = false;
            }
        }

        public void ClickMultiplier()
        {
            switch (_businessConfig.Values.LvlOfBusiness)
            {
                case 0:
                    _businessConfig.Values.LvlUpPrice *= _businessConfig.Values.NextLevelMultiplier;
                    _lvlUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Lvl Up \n Price: " +
                        _businessConfig.Values.LvlUpPrice.ToString("0.00")+ "$";
                    _lvlUpButton.interactable = true;
                    _businessConfig.Values.LvlOfBusiness++;
                    break;
                case 1:
                    _businessConfig.Values.LvlUpPrice *= _businessConfig.Values.NextLevelMultiplier;
                    _lvlUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Lvl Up \n Price: " + 
                        _businessConfig.Values.LvlUpPrice.ToString("0.00") + "$";
                    _lvlUpButton.interactable = true;
                    _businessConfig.Values.LvlOfBusiness++;
                    break;
                case 2:
                    _businessConfig.Values.LvlUpPrice *= _businessConfig.Values.NextLevelMultiplier;
                    _lvlUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Lvl Up \n Price: " +
                        _businessConfig.Values.LvlUpPrice.ToString("0.00") + "$";
                    _lvlUpButton.interactable = true;
                    _businessConfig.Values.LvlOfBusiness++;
                    break;
                case 3:
                    _businessConfig.Values.LvlUpPrice *= _businessConfig.Values.NextLevelMultiplier;
                    _lvlUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Lvl Up \n Price: " + 
                        _businessConfig.Values.LvlUpPrice.ToString("0.00") + "$";
                    _lvlUpButton.interactable = true;
                    _businessConfig.Values.LvlOfBusiness++;
                    break;
                case 4:
                    _lvlUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Max Level";
                    _businessConfig.Values.LvlOfBusiness++;
                    _lvlUpButton.interactable = false;
                    _businessConfig.Values.LvllUpButActivity = false;
                    break;
            }
        }
    }
}