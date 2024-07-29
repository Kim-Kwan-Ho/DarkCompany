using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeEmployee : BaseBehaviour
{
    [SerializeField] private Transform _popupCanvas;
    [SerializeField] private GameObject _employeeUpgradeStat;
    private EmployeeStats _stat;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Button _upgradeButton;
    protected override void Awake()
    {
        base.Awake();
        _upgradeButton.onClick.AddListener(Upgrade);
        _popupCanvas = GameObject.Find("PopupCanvas").transform;
    }

    public void SetEmployee(EmployeeStats stat)
    {
        _stat = stat;
        _nameText.text = _stat.Name;
    }
    private void OnEnable()
    {
        EmployeeManager.Instance.EventEmployee.OnEmployeeDeath += Event_OnEmployeeDeath;
    }

    private void OnDisable()
    {
        EmployeeManager.Instance.EventEmployee.OnEmployeeDeath -= Event_OnEmployeeDeath;
    }
    private void Event_OnEmployeeDeath(EmployeeDeathEventArgs employeeDeathEventArgs)
    {
        if (employeeDeathEventArgs.index == _stat.Index)
        {
            Destroy(this.gameObject);
        }
    }

    private void Upgrade()
    {
        EmployeeUpgradeStat emp = Instantiate(_employeeUpgradeStat, _popupCanvas).GetComponent<EmployeeUpgradeStat>();
        emp.SetStat(_stat);
    }

#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        _nameText = FindGameObjectInChildren<TextMeshProUGUI>("NameText");
        _employeeUpgradeStat = Resources.Load<GameObject>("UI/EmployeeUpgradeStat");
        _upgradeButton = FindGameObjectInChildren<Button>("UpgradeButton");
    }
#endif
}
