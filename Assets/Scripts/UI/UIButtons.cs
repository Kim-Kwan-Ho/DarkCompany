using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtons : BaseBehaviour
{
    [SerializeField] private Button _officeUpgradeButton;
    [SerializeField] private Button _employeeManagementButton;
    [SerializeField] private Button _addEnvironmentButton;


    protected override void Initialize()
    {
        base.Initialize();
        _officeUpgradeButton.onClick.AddListener(OpenOfficePopup);
        _employeeManagementButton.onClick.AddListener(OpenEmployPopup);
        _addEnvironmentButton.onClick.AddListener(OpenEnvironmentPopup);
    }


    private void OpenOfficePopup()
    {
        UIManager.Instance.OpenPopup<OfficeUpgradePopup>();
    }

    private void OpenEmployPopup()
    {
        UIManager.Instance.OpenPopup<EmployeeManagement>();
    }

    private void OpenEnvironmentPopup()
    {
        UIManager.Instance.OpenPopup<EnvironmentPopup>();
    }
#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        _officeUpgradeButton = FindGameObjectInChildren<Button>("OfficeUpgradeButton");
        _employeeManagementButton = FindGameObjectInChildren<Button>("EmployeeManagementButton");
        _addEnvironmentButton = FindGameObjectInChildren<Button>("AddEnvironmentsButton");
    }

#endif



}
