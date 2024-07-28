
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
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
    public int PayTime;
    public int Stress;
    public bool IsSleeping;
    private int _index;
    private bool _isDeath;
    public int Index { get { return _index; } }
    public List<EmployeeSkill> EmployeeSkills;
    public EmployeeSkillStat SkillStat;




    public EmployeeStats(EmployeeSkill[] skills)
    {
        Ability = 1;
        Considerate = 1;
        Guts = 1;
        Stress = GameRule.STRESS_MIN;
        Pay = Random.Range(GameProbability.EMPLOYEE_START_PAY_MIN, GameProbability.EMPLOYEE_START_PAY_MAX);
        _isDeath = false;
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
        SkillStat = new EmployeeSkillStat();
        EmployeeSkills = skills.ToList();

        foreach (var VARIABLE in skills)
        {
            AddSkillStat(VARIABLE.Stat);
        }
        PayTime = Random.Range(GameRule.PAY_TIME_MIN, GameRule.PAY_TIME_MAX) + SkillStat.PayTime;

    }

    public void AddSkill(EmployeeSkill skill)
    {
        EmployeeSkills.Add(skill);
        AddSkillStat(skill.Stat);
    }
    public void AddSkillStat(EmployeeSkillStat stat)
    {
        SkillStat.PayTime += stat.PayTime;
        SkillStat.PayBuff += stat.PayBuff;
        SkillStat.RunawayPercent += stat.RunawayPercent;
        SkillStat.StressBuff += stat.StressBuff;
        SkillStat.WorkTime += stat.WorkTime;
    }

    public void RemoveSkillStat(EmployeeSkillStat stat)
    {
        SkillStat.PayTime -= stat.PayTime;
        SkillStat.PayBuff -= stat.PayBuff;
        SkillStat.RunawayPercent -= stat.RunawayPercent;
        SkillStat.StressBuff -= stat.StressBuff;
        SkillStat.WorkTime -= stat.WorkTime;
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
        if (IsSleeping)
            return;

        CheckWorkTime();
        CheckPayTime();
        MakeMoney();
    }

    private void CheckWorkTime()
    {
        if (GameSceneManager.Instance.GameTime > GameRule.COMPANY_LEAVE_TIME + SkillStat.WorkTime)
        {
            IncreaseStress(true, 20);
        }
    }
    private void CheckPayTime()
    {
        if (PayTime <= 0)
        {
            IncreaseStress(true, 10);
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

    public void GoHome()
    {
        IsSleeping = true;
        if (GameSceneManager.Instance.GameTime >= GameRule.COMPANY_CLOSE_TIME)
            return;
        Stress -= (GameRule.COMPANY_CLOSE_TIME - GameSceneManager.Instance.GameTime) * GameRule.STRESS_DECREASE_AMOUNT;
        if (Stress < 0)
            Stress = 0;
    }
    private void MakeMoney()
    {
        //이것도 고쳐야함
        int amount = 100;
        amount += (int)(amount * (EmployeeManager.Instance.PayBuff / 100f));
        EmployeeManager.Instance.EventEmployee.CallEmployeeMadeMoney(_index, amount);
        GameSceneManager.Instance.EventGameScene.CallMoneyChanged(amount);
    }
    public void IncreaseStress(bool paymentStressed, int amount)
    {
        // 고쳐야함
        if (_isDeath)
            return;
        amount = (int)(amount - ((amount * SkillStat.StressBuff) / 100));
        Stress += amount;
        Stress = Math.Min(Stress, 200);
        EmployeeManager.Instance.EventEmployee.CallEmployeeStressed(_index, amount);

        if (Stress == 200)
        {
            _isDeath = true;
            EmployeeDeath();
        }
    }

    public void InDeCreaseStress(bool increase, int amount)
    {
        if (increase)
        {
            Stress += amount;
        }
        else
        {
            Stress -= amount;
        }
        if (Stress > 200)
            Stress = 200;
        else if (Stress < 0)
            Stress = 0;

        if (Stress == 200)
        {
            _isDeath = true;
            EmployeeDeath();
        }
    }

    private void EmployeeDeath()
    {
        UIManager.Instance.OpenWarningPopup(Name + "이 스트레스로 인해 사망하였습니다.");
        EmployeeManager.Instance.EventEmployee.CallEmployeeDeath(_index);

    }
    public void GoToWorkEmployee()
    {
        // 확률적 출근은 여기서 수정
        IsSleeping = false;
        EmployeeManager.Instance.EventEmployee.CallEmployeeGoToWork(_index);
    }

    public void GetPayed()
    {
        PayTime = Random.Range(GameRule.PAY_TIME_MIN, GameRule.PAY_TIME_MAX) + SkillStat.PayTime;
    }

}


