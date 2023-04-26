using Configs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountOfClicks : Achievement
{

    [SerializeField] private AchievementsBase _achievementsBase;
    [SerializeField] private BusinessConfig _businessConfig;

    // Постоянный множитель для кликов
    const int COUNT_OF_ACHIEVEMENT = 5;  // Количество Достижений

    [SerializeField] private float currentClickMultiply = 1f;    // Текущий передающийся множитель
    private float currentClickMultiply_2 = 1f;  // Бонус за достижение

    [SerializeField] private float[] clickMultiply = new float[COUNT_OF_ACHIEVEMENT] { 1.1f, 1.3f, 1.5f, 1.8f, 2f }; // Множитель для каждого бизнеса
    [SerializeField] private int[] checkClicks = new int[COUNT_OF_ACHIEVEMENT] { 5, 1000, 2500, 5000, 10_000 };     // Множитель для каждого бизнеса

    public void NumberOfClicks() // +++ Кнопка
    {
        _achievementsBase.numOfClicks++;

        for (int i = 0; i < COUNT_OF_ACHIEVEMENT; i++)
        {
            if (_achievementsBase.numOfClicks == checkClicks[i])
            {
                currentClickMultiply_2 = clickMultiply[i];
                AchieveEverything();
                break;
            }
        }
        currentClickMultiply = currentClickMultiply_2 + achievements; // В конфиг отлетает
        _businessConfig.Values.profitValue *= currentClickMultiply;
       // return currentClickMultiply;    
    }
}