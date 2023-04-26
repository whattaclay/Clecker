using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevel : Achievement
{
    // Проверка открытых бизнесов и раздача множителей
    private int countOpenBusiness = 0;  // Количество открытых бизнесов
    private int iterationMultiply;      // Множитель за производство
    [SerializeField] private int[] randomRange = new int[6] { 120, 200, 300, 500, 800, 1000 };   // Множитель для бизнесов
    [SerializeField] private int[] currentIterationRange = new int[2] { 100, 100 };              // Текущий множитель для бизнесов

    public void FirstLevelOfBusiness(int businessNumber, bool firstLevel) // +++ Кнопка
    {
        if (firstLevel)
        {
            // Если был открыт больший бизнес то не присваиваем
            if (randomRange[businessNumber] > currentIterationRange[0])
            {
                currentIterationRange[0] = randomRange[businessNumber];
                currentIterationRange[1] = randomRange[businessNumber + 1];
            }
            countOpenBusiness++;
            AchieveEverything();
        }
    }

    // Шанс на множитель дохода для всех бизнесов за итерацию
    public int FirstLevelOfBusinessReward() // +++ Привязан к Корутине
    {
        int chance = Random.Range(countOpenBusiness, 10);
        if (10 == chance)
        {
            iterationMultiply = Random.Range(currentIterationRange[0], currentIterationRange[1]);
            return iterationMultiply;
        }
        return 100;
    }
}