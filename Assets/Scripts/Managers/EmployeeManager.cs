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
        GameSceneManager.Instance.EventGameScene.OnNewDayStart += Event_OnNewDayStart;
        EventEmployee.OnEmployeeFired += Event_EmployFired;
    }

    private void OnDisable()
    {
        GameSceneManager.Instance.EventGameScene.OnNewDayStart -= Event_OnNewDayStart;
        EventEmployee.OnEmployeeFired -= Event_EmployFired;
    }


    private void Event_OnNewDayStart()
    {
        WakeUpEmployee();
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

    private void WakeUpEmployee()
    {
        for (int i = 0; i < _employees.Length; i++)
        {
            if (_employees[i] != null)
            {
                _employees[i].IsSleeping = false;
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
#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        EventEmployee = GetComponent<EmployeeEvent>();

    }
#endif
}
