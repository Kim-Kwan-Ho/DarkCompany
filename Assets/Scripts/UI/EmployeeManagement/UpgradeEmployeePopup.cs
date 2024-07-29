using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeEmployeePopup : UIPopup
{
    [SerializeField] private GameObject _upgradeEmployee;
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private Button _closeButton;

    protected override void Awake()
    {
        base.Awake();
        SetEmployees();
        _closeButton.onClick.AddListener(ClosePopup);
    }

    private void SetEmployees()
    {
        for (int i = 0; i < GameRule.MAX_EMPLOYEE_COUNT; i++)
        {
            if (EmployeeManager.Instance.Employees[i] != null)
            {
                UpgradeEmployee up = Instantiate(_upgradeEmployee, _spawnPos).GetComponent<UpgradeEmployee>();
                up.SetEmployee(EmployeeManager.Instance.Employees[i]);
            }
        }
    }

#if UNITY_EDITOR

    protected override void OnBindField()
    {
        base.OnBindField();
        _upgradeEmployee = Resources.Load<GameObject>("UI/UpgradeEmployee");
        _spawnPos = FindGameObjectInChildren<Transform>("SpawnPos");
        _closeButton = FindGameObjectInChildren<Button>("CloseButton");
    }

#endif

}
