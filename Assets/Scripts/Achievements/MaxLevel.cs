using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxLevel : Achievement
{
    // ��������� � ���������� �������. �������� ����� ������� ���� �� MaxLevel
    const int COUNT_OF_BUSINESS = 5;    // ���������� ��������
    float[] maxMultiply = new float[COUNT_OF_BUSINESS] { 1.5f, 2, 4, 6, 10 };     // ��������� ��� ������� �������
    float[] currentMaxMultiply = new float[COUNT_OF_BUSINESS] { 1, 1, 1, 1, 1 };  // ������� ��������� ��� ������� �������
    public void MaxBusinessLevel(int businessNumber, int maxLevel)   // +++ ������
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