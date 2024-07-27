
using System;
using System.IO;
using Random = UnityEngine.Random;

public class EmployeeStats
{
    public string Name;
    public int Ability;
    public int MaxAbility;
    public int Considerate;
    public int MaxConsiderate;
    public int Guts;
    public int MaxGuts;
    public int Pay;
    private int PayTime;
    public int Stress;
    public bool IsSleeping;
    private int _index;
    public int Index { get { return _index; } }
    public EmployeeStats()
    {
        Ability = 1;
        Considerate = 1;
        Guts = 1;
        Stress = GameRule.STRESS_MIN;
        Pay = Random.Range(GameProbability.EMPLOYEE_START_PAY_MIN, GameProbability.EMPLOYEE_START_PAY_MAX);
        PayTime = GameRule.PAY_TIME;
        int totalStat = Random.Range(GameProbability.EMPLOYEE_START_STATS_MIN, GameProbability.EMPLOYEE_START_STATS_MAX) - 3;

        Ability += Random.Range(0, totalStat + 1);
        totalStat -= Ability - 1;
        Considerate += Random.Range(0, totalStat + 1);
        totalStat -= Considerate - 1;
        Guts += totalStat;


        MaxAbility = Random.Range(GameProbability.EMPLOYEE_MAX_STATS_MIN, GameProbability.EMPLOYEE_MAX_STATS_MAX);
        MaxConsiderate = Random.Range(GameProbability.EMPLOYEE_MAX_STATS_MIN, GameProbability.EMPLOYEE_MAX_STATS_MAX);
        MaxGuts = Random.Range(GameProbability.EMPLOYEE_MAX_STATS_MIN, GameProbability.EMPLOYEE_MAX_STATS_MAX);

        Name = "";
        Name += Names.FIRST_NAME[Random.Range(0, Names.FIRST_NAME.Length)];
        Name += Names.LAST_NAME[Random.Range(0, Names.LAST_NAME.Length)];
        Name += Names.LAST_NAME[Random.Range(0, Names.LAST_NAME.Length)];
        IsSleeping = false;
    }

    public void SetIndex(int index)
    {
        _index = index;
    }
    public void UpgradeEmployee()
    {

    }

    public void IncreaseTime()
    {

    }

    private void CheckPayTime()
    {
        if (PayTime <= 0)
        {
            IncreaseStress(true);
        }
        else if (PayTime == 1)
        {
            EmployeeManager.Instance.EventEmployee.CallEmployeeRequestPay(_index);
            PayTime--;
        }
        else
        {
            PayTime--;
        }
    }

    private void IncreaseStress(bool paymentStressed)
    {
        // 고쳐야함
        int amount = 10;
        EmployeeManager.Instance.EventEmployee.CallEmployeeStressed(_index, amount);
    }



}
