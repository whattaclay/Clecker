using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxLevel : Achievement
{
    // Привязана к отдельному бизнесу. Умножает доход бизнеса если он MaxLevel
    const int COUNT_OF_BUSINESS = 5;    // Количество бизнесов
    float[] maxMultiply = new float[COUNT_OF_BUSINESS] { 1.5f, 2, 4, 6, 10 };     // Множитель для каждого бизнеса
    float[] currentMaxMultiply = new float[COUNT_OF_BUSINESS] { 1, 1, 1, 1, 1 };  // Текущий множитель для каждого бизнеса
    public void MaxBusinessLevel(int businessNumber, int maxLevel)   // +++ Кнопка
    {
        if (maxLevel != 3) return;

        for (int i = 0; i < COUNT_OF_BUSINESS; i++)
        {
            if (businessNumber == i)
            {
                currentMaxMultiply[i] = maxMultiply[i];
                AchieveEverything();
                break;
            }                
        }
    }
}