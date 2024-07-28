using System;
using UnityEngine;


[CreateAssetMenu(fileName = "Skill_", menuName = "Scriptable Objects/Skills/Skill")]
public class EmployeeSkill : ScriptableObject
{
    public string SkillName;
    public bool IsPositive;
    public EmployeeSkillStat Stat;
}

[Serializable]
public class EmployeeSkillStat
{
    public int WorkTime = 0;
    public int PayTime = 0;
    public int StressBuff = 0;
    public int PayBuff = 0;
    public int RunawayPercent = 0;
}
