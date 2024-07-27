using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeSlot : BaseBehaviour
{
    [SerializeField] private Transform _popupCanvas;
    [SerializeField] private Button _openSlotButton;
    [SerializeField] private GameObject _employee;
    [SerializeField] private GameObject _sleepingEmployee;
    [SerializeField] private GameObject _employeeStatInfo;
    [SerializeField] private EmployeeStats _stats;
    [SerializeField] private EmployeeStatInfo _statInfo;
    [SerializeField] private TextMeshProUGUI _indexText;
    [SerializeField] private Button _givePayButton;
    private int _index;
    protected override void Awake()
    {
        base.Awake();
        _popupCanvas = GameObject.Find("PopupCanvas").transform;
        _openSlotButton.onClick.AddListener(OpenSlot);
    }

    private void OnEnable()
    {
        EmployeeManager.Instance.EventEmployee.OnEmployeeFired += Event_EmployeeFired;
    }

    private void OnDisable()
    {
        EmployeeManager.Instance.EventEmployee.OnEmployeeFired -= Event_EmployeeFired;
    }


    private void Update()
    {

        if (_stats == null)
        {
            _openSlotButton.interactable = false;
            return;
        }
        else if (_stats.IsSleeping)
        {
            _openSlotButton.interactable = false;
            _sleepingEmployee.SetActive(true);
        }
        else
        {
            _openSlotButton.interactable = true;
            _sleepingEmployee.SetActive(false);
        }
        _employee.SetActive(_stats != null);
    }
    private void OpenSlot()
    {
        _statInfo = Instantiate(_employeeStatInfo, _popupCanvas).GetComponent<EmployeeStatInfo>();
        _statInfo.SetStatInfo(_stats, _index);
    }

    public void SetSlot(EmployeeStats stat, int index)
    {
        _stats = stat;
        _index = index;
        _indexText.text = (index + 1).ToString();
    }

    private void Event_EmployeeFired(EmployeeFireEventArgs employeeFireEventArgs)
    {
        if (_index == employeeFireEventArgs.index)
        {
            _stats = null;
        }
    }

#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnButtonField();
        _openSlotButton = GetComponent<Button>();
        _employee = FindGameObjectInChildren("Employee");
        _sleepingEmployee = FindGameObjectInChildren("SleepingEmployee");
        _employeeStatInfo = Resources.Load<GameObject>("UI/EmployeeStatInfo");
        _indexText = FindGameObjectInChildren<TextMeshProUGUI>("IndexText");
        _givePayButton = FindGameObjectInChildren<Button>("GivePayButton");
    }


#endif

}
