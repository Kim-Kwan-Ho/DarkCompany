using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtons : BaseBehaviour
{
    [SerializeField] private Button _officeUpgradeButton;
    [SerializeField] private Button _employeeManagementButton;


    protected override void Initialize()
    {
        base.Initialize();
        _officeUpgradeButton.onClick.AddListener(OpenOfficePopup);
        _employeeManagementButton.onClick.AddListener(OpenEmployPopup);
    }


    private void OpenOfficePopup()
    {
        UIManager.Instance.OpenPopup<OfficeUpgradePopup>();
    }

    private void OpenEmployPopup()
    {
        UIManager.Instance.OpenPopup<EmployeeManagement>();
    }


#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        _officeUpgradeButton = FindGameObjectInChildren<Button>("OfficeUpgradeButton");
        _employeeManagementButton = FindGameObjectInChildren<Button>("EmployeeManagementButton");
    }

#endif



}
