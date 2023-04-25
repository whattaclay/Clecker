using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cases : Achievement
{
    [SerializeField] const int COUNT_CHANCE = 5;         // Количество шансов на кейс
    [SerializeField] const int COUNT_OF_CASES = 11;      // Количество кейсов
    [SerializeField] int[] chance = new int[COUNT_CHANCE] { 60, 85, 95, 99, 100 };                  // Шансы на кейсы
    [SerializeField] float[] dropMultiply = new float[COUNT_CHANCE] { 0.4f, 1.5f, 3f, 5f, 20f };    // Множитель кейсов
    [SerializeField] float[] сaseСost = new float[COUNT_OF_CASES] { 10, 50, 150, 500, 1000, 3000, 7500, 10_000, 25_000, 50_000, 100_000 };            // Стоимость кейсов
    [SerializeField] int[] balance = new int[COUNT_OF_CASES + 1] { 0, 50, 250, 750, 2500, 5000, 15000, 37500, 50_000, 125_000, 250_000, 500_000 };    // Промежуток баланса для кейсов
    private int extraCaseChance = 1;    // Шанс на Экстра множитель

    public float OpenCase()   // Кнопка
    {
        int currentBalance = 0;         // Присвоить balanceConfig;
        float reward = сaseСost[0];     // Стоимость первого кейса

        // Назначаем цену кейса
        for (int i = 0; i < COUNT_OF_CASES; i++)
            if (balance[i] > currentBalance && currentBalance <= balance[i + 1])
            {
                reward = сaseСost[i];
                // Закинуть в текстовое поле цену
                break;
            }

        // Получить шанс множителя для награды
        int extra = 1;
        if (100 - extraCaseChance <= Random.Range(1, 100))
            extra = 3;

        // Шанс на награду
        var caseChance = Random.Range(1, 100);
        if (chance[0] <= caseChance)
            reward *= dropMultiply[0] * extra;
        for (int i = 0; i < COUNT_CHANCE - 1; i++)
        {
            if (chance[i] > caseChance && caseChance <= chance[i + 1])
                reward *= dropMultiply[i + 1] * extra;
        }
        if (chance[4] == caseChance)
            reward *= dropMultiply[4] * extra;

        NumberOfOpenCases();
        return reward;
    }

    // Количество открытых кейсов + Шанс на extraCase
    private float extraCase = 0f;
    public void NumberOfOpenCases() // +++
    {
        extraCase++;
        switch (extraCase)
        {
            case 10:
                extraCaseChance = 2;
                AchieveEverything();
                break;
            case 50:
                extraCaseChance = 5;
                AchieveEverything();
                break;
            case 100:
                extraCaseChance = 8;
                AchieveEverything();
                break;
            case 250:
                extraCaseChance = 10;
                AchieveEverything();
                break;
            case 1000:
                extraCaseChance = 15;
                AchieveEverything();
                break;
        }
    }
}