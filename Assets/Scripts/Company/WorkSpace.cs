using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkSpace : BaseBehaviour
{
    [SerializeField] private GameObject[] _employees;
    [SerializeField] private GameObject[] _levels;
    private int _index;
    protected override void Initialize()
    {
        base.Initialize();
        foreach (var VARIABLE in _employees)
        {
            VARIABLE.SetActive(false);
        }

        _index = 0;
    }

    private void OnEnable()
    {
        EmployeeManager.Instance.EventEmployee.OnEmployeeHired += Event_EmployeeHired;
        EmployeeManager.Instance.EventEmployee.OnEmployeeFired += Event_EmployeeFired;
        EmployeeManager.Instance.EventEmployee.OnEmployeeLeaveWork += Event_LeaveWorkEmployee;
        EmployeeManager.Instance.EventEmployee.OnEmployeeGoToWork += Event_GoToWorkEmployee;
        UpgradeManager.Instance.EventUpgrade.OnCompanyUpgrade += Event_CompanyUpgraded;

    }

    private void OnDisable()
    {
        EmployeeManager.Instance.EventEmployee.OnEmployeeHired -= Event_EmployeeHired;
        EmployeeManager.Instance.EventEmployee.OnEmployeeFired -= Event_EmployeeFired;
        EmployeeManager.Instance.EventEmployee.OnEmployeeLeaveWork -= Event_LeaveWorkEmployee;
        EmployeeManager.Instance.EventEmployee.OnEmployeeGoToWork -= Event_GoToWorkEmployee;
        UpgradeManager.Instance.EventUpgrade.OnCompanyUpgrade -= Event_CompanyUpgraded;
    }


    private void Event_EmployeeHired(EmployeeHiredEventArgs employeeHiredEventArgs)
    {
        _employees[employeeHiredEventArgs.index].SetActive(true);
    }

    private void Event_EmployeeFired(EmployeeFireEventArgs employeeFireEventArgs)
    {
        _employees[employeeFireEventArgs.index].SetActive(false);
    }

    private void Event_LeaveWorkEmployee(EmployeeLeaveWorkEventArgs employeeLeaveWorkEventArgs)
    {
        _employees[employeeLeaveWorkEventArgs.index].SetActive(false);
    }
    private void Event_GoToWorkEmployee(EmployeeGoToWorkEventArgs employeeGoToWorkEventArgs)
    {
        _employees[employeeGoToWorkEventArgs.index].SetActive(true);
    }
    private void Event_CompanyUpgraded()
    {
        _levels[_index].SetActive(true);
        _index++;
    }

}
