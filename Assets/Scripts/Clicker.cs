using System;
using Configs;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Clicker: MonoBehaviour
{
    [SerializeField] private BusinessConfig businessConfig;
    [SerializeField] private BalanceConfig balanceConfig;
    /*[SerializeField] private TextMeshProUGUI _flyingText;
        [SerializeField] private RectTransform _flyPosition;
        private float coolDown = 0f;*/
    public void ByClick()
    {
        balanceConfig.Balance.BalanceValue += businessConfig.Values.ProfitValue / 30;
        /*FlyingText();*/
    }

    /*private void FlyingText()
        {
            coolDown = 1f;
            var textSpawn = Instantiate(_flyingText, _flyPosition);
            _flyingText.text = _businessConfig.Values.ProfitValue + "$";
            while (coolDown>=0)
            {
                
            }
            Destroy(textSpawn.gameObject);
        }

        private void Update()
        {
            if (coolDown >0)
            {
                coolDown -= Time.deltaTime;
            }
        }*/
}