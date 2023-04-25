using Configs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountOfClicks : Achievement
{

    [SerializeField] private AchievementsBase _achievementsBase;
    [SerializeField] private BusinessConfig _businessConfig;

    // ���������� ��������� ��� ������
    const int COUNT_OF_ACHIEVEMENT = 5;  // ���������� ����������

    [SerializeField] private float currentClickMultiply = 1f;    // ������� ������������ ���������
    private float currentClickMultiply_2 = 1f;  // ����� �� ����������

    [SerializeField] private float[] clickMultiply = new float[COUNT_OF_ACHIEVEMENT] { 1.1f, 1.3f, 1.5f, 1.8f, 2f }; // ��������� ��� ������� �������
    [SerializeField] private int[] checkClicks = new int[COUNT_OF_ACHIEVEMENT] { 5, 1000, 2500, 5000, 10_000 };     // ��������� ��� ������� �������

    public void NumberOfClicks() // +++ ������
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
        currentClickMultiply = currentClickMultiply_2 + achievements; // � ������ ��������
        _businessConfig.Values.profitValue *= currentClickMultiply;
       // return currentClickMultiply;    
    }
}