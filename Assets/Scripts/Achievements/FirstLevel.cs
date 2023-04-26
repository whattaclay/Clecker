using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevel : Achievement
{
    // �������� �������� �������� � ������� ����������
    private int countOpenBusiness = 0;  // ���������� �������� ��������
    private int iterationMultiply;      // ��������� �� ������������
    [SerializeField] private int[] randomRange = new int[6] { 120, 200, 300, 500, 800, 1000 };   // ��������� ��� ��������
    [SerializeField] private int[] currentIterationRange = new int[2] { 100, 100 };              // ������� ��������� ��� ��������

    public void FirstLevelOfBusiness(int businessNumber, bool firstLevel) // +++ ������
    {
        if (firstLevel)
        {
            // ���� ��� ������ ������� ������ �� �� �����������
            if (randomRange[businessNumber] > currentIterationRange[0])
            {
                currentIterationRange[0] = randomRange[businessNumber];
                currentIterationRange[1] = randomRange[businessNumber + 1];
            }
            countOpenBusiness++;
            AchieveEverything();
        }
    }

    // ���� �� ��������� ������ ��� ���� �������� �� ��������
    public int FirstLevelOfBusinessReward() // +++ �������� � ��������
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