using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddSkillEmployee : BaseBehaviour
{

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Button _addButton;
    [SerializeField] private TextMeshProUGUI _moneyText;
    private EmployeeStats _stats;
    private int _index;


    protected override void Awake()
    {
        base.Awake();
        _addButton.onClick.AddListener(AddSkill);
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
        if (employeeDeathEventArgs.index == _index)
        {
            Destroy(this.gameObject);
        }
    }
    public void SetAddSkillEmployee(EmployeeStats stats)
    {
        _stats = stats;
        _nameText.text = stats.Name;
        _index = stats.Index;
    }

    private void Update()
    {

        if (_stats.EmployeeSkills.Count >= 2)
        {
            _addButton.interactable = false;
            _moneyText.text = "Max";
            _moneyText.color = Color.black;
        }
        else
        {
            _moneyText.text = "$" + ((_stats.EmployeeSkills.Count + 1) * 500).ToString();
        }
    }
    public void AddSkill()
    {
        if (_stats.EmployeeSkills.Count >= 2)
        {
            UIManager.Instance.OpenNoticePopup("잔액이 부족합니다.");
            return;
        }

        int amount = (_stats.EmployeeSkills.Count + 1) * 500;
        if (GameSceneManager.Instance.CurrentMoney >= amount)
        {
            EmployeeManager.Instance.EventEmployee.CallEmployeeSkillAdded(_index);
            GameSceneManager.Instance.EventGameScene.CallMoneyChanged(-amount);
        }
    }



#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        _nameText = FindGameObjectInChildren<TextMeshProUGUI>("NameText");
        _moneyText = FindGameObjectInChildren<TextMeshProUGUI>("MoneyText");
        _addButton = FindGameObjectInChildren<Button>("AddButton");

    }
#endif 

}
