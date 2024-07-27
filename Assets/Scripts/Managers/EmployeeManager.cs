using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



[RequireComponent(typeof(EmployeeEvent))]
public class EmployeeManager : BaseBehaviour
{
    public static EmployeeManager Instance;
    public EmployeeEvent EventEmployee;
    private HashSet<EmployeeStats> _newEmployees;
    public HashSet<EmployeeStats> NewEmployees { get { return _newEmployees; } }

    private EmployeeStats[] _employees;
    public EmployeeStats[] Employees { get { return _employees; } }
    private int _employeeCount;
    protected override void Awake()
    {
        base.Awake();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }
    }

    protected override void Initialize()
    {
        base.Initialize();
        _employeeCount = 0;
        _employees = new EmployeeStats[GameRule.MAX_EMPLOYEE_COUNT];
    }

    private void OnEnable()
    {
        GameSceneManager.Instance.EventGameScene.OnTimeChanged += Event_TimeChanged;
        GameSceneManager.Instance.EventGameScene.OnNewDayStart += Event_OnNewDayStart;
        EventEmployee.OnEmployeeFired += Event_EmployFired;
        EventEmployee.OnEmployeeGetPayed += Event_EmployeeGetPayed;
    }

    private void OnDisable()
    {
        GameSceneManager.Instance.EventGameScene.OnTimeChanged -= Event_TimeChanged;
        GameSceneManager.Instance.EventGameScene.OnNewDayStart -= Event_OnNewDayStart;
        EventEmployee.OnEmployeeFired -= Event_EmployFired;
        EventEmployee.OnEmployeeGetPayed -= Event_EmployeeGetPayed;
    }

    private void Event_TimeChanged()
    {
        foreach (var VARIABLE in _employees)
        {
            if (VARIABLE != null)
            {
                VARIABLE.IncreaseTime();
            }
        }
    }
    private void Event_OnNewDayStart()
    {
        GoToWorkEmployees();
        CreateNewEmployee();
    }


    private void CreateNewEmployee()
    {
        int c = UpgradeManager.Instance.RecruitLevel;

        _newEmployees = new HashSet<EmployeeStats>();
        for (int i = 0; i < c; i++)
        {
            _newEmployees.Add(new EmployeeStats());
        }
    }

    private void GoToWorkEmployees()
    {
        for (int i = 0; i < _employees.Length; i++)
        {
            if (_employees[i] != null)
            {
                _employees[i].GoToWorkEmployee();
            }
        }
    }
    public void HireEmployee(EmployeeStats stats)
    {
        for (int i = 0; i < UpgradeManager.Instance.CompanyLevel * 2; i++)
        {
            if (_employees[i] == null)
            {
                _employees[i] = stats;
                _employees[i].SetIndex(i);
                _newEmployees.Remove(stats);
                EventEmployee.CallEmployeeHired(stats, i);
                _employeeCount++;
                break;
            }
        }
    }

    public bool CanHireEmployee()
    {
        if (_employeeCount < UpgradeManager.Instance.CompanyLevel * 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Event_EmployFired(EmployeeFireEventArgs employeeFireEventArgs)
    {
        _employeeCount--;
        _employees[employeeFireEventArgs.index] = null;
    }

    private void Event_EmployeeGetPayed(EmployeeGetPayedEventArgs employeeGetPayedEventArgs)
    {
        _employees[employeeGetPayedEventArgs.index].GetPayed();
    }
#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        EventEmployee = GetComponent<EmployeeEvent>();

    }
#endif
}
