using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour
{
    // Дополнительный множитель для кликов за количество выполненных достижений
    private int completedAchievements = 0;
    protected float achievements = 0;

    public void AchieveEverything()         // +++
    {
        completedAchievements++;
        achievements += completedAchievements * 10 / 100; // + 10% Процентов за ачивку
    }
}