using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillAddPopup : UIPopup
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private GameObject _employeeSkillAdd;


    protected override void Awake()
    {
        base.Awake();
        _closeButton.onClick.AddListener(ClosePopup);
        InstantiateEmployees();
    }


    private void InstantiateEmployees()
    {
        for (int i = 0; i < EmployeeManager.Instance.Employees.Length; i++)
        {
            if (EmployeeManager.Instance.Employees[i] != null)
            {
                AddSkillEmployee employee = Instantiate(_employeeSkillAdd, _spawnPos).GetComponent<AddSkillEmployee>();
                employee.SetAddSkillEmployee(EmployeeManager.Instance.Employees[i]);
            }
        }

    }



#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        _closeButton = FindGameObjectInChildren<Button>("CloseButton");
        _spawnPos = FindGameObjectInChildren<Transform>("SpawnPos");
        _employeeSkillAdd = Resources.Load<GameObject>("UI/AddSkillEmployee");
    }
#endif

}
