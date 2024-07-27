using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeSlots : BaseBehaviour
{
    [SerializeField] private GameObject _employSlot;
    [SerializeField] private List<EmployeeSlot> _slots = new List<EmployeeSlot>();

    protected override void Initialize()
    {
        base.Initialize();
        _slots.Add(Instantiate(_employSlot, transform).GetComponent<EmployeeSlot>());
        _slots[0].SetSlot(null, 0);
        _slots.Add(Instantiate(_employSlot, transform).GetComponent<EmployeeSlot>());
        _slots[1].SetSlot(null, 1);

    }

    private void OnEnable()
    {
        UpgradeManager.Instance.EventUpgrade.OnCompanyUpgrade += Event_OnCompanyUpgrade;
        EmployeeManager.Instance.EventEmployee.OnEmployeeHired += Event_OnEmployeeHired;
    }

    private void OnDisable()
    {
        UpgradeManager.Instance.EventUpgrade.OnCompanyUpgrade -= Event_OnCompanyUpgrade;
        EmployeeManager.Instance.EventEmployee.OnEmployeeHired += Event_OnEmployeeHired;
    }

    private void Event_OnCompanyUpgrade()
    {
        _slots.Add(Instantiate(_employSlot, transform).GetComponent<EmployeeSlot>());
        _slots[_slots.Count - 1].SetSlot(null, _slots.Count - 1);
        _slots.Add(Instantiate(_employSlot, transform).GetComponent<EmployeeSlot>());
        _slots[_slots.Count - 1].SetSlot(null, _slots.Count - 1);
    }

    private void Event_OnEmployeeHired(EmployeeHiredEventArgs employeeHiredEventArgs)
    {
        _slots[employeeHiredEventArgs.index].SetSlot(employeeHiredEventArgs.stat, employeeHiredEventArgs.index);

    }


#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        _employSlot = Resources.Load<GameObject>("UI/EmployeeSlot");
    }
#endif
}
