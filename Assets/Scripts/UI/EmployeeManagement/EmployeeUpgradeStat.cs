using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeUpgradeStat : UIPopup
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _abilityText;
    [SerializeField] private TextMeshProUGUI _abilityAmountText;
    [SerializeField] private Button _abilityUpgradeButton;
    [SerializeField] private TextMeshProUGUI _considerateText;
    [SerializeField] private TextMeshProUGUI _considerateAmountText;
    [SerializeField] private Button _considerateUpgradeButton;
    [SerializeField] private TextMeshProUGUI _gutsText;
    [SerializeField] private TextMeshProUGUI _gutsAmountText;
    [SerializeField] private Button _gutsUpgradeButton;
    [SerializeField] private Button _closeButton;
    private EmployeeStats _stats;


    protected override void Awake()
    {
        base.Awake();
        _closeButton.onClick.AddListener(ClosePopup);
        _abilityUpgradeButton.onClick.AddListener(UpgradeAbility);
        _considerateUpgradeButton.onClick.AddListener(UpgradeConsiderate);
        _gutsUpgradeButton.onClick.AddListener(UpgradeGuts);
    }

    private void OnEnable()
    {
        GameSceneManager.Instance.EventGameScene.OnDayEnd += ClosePopup;
        EmployeeManager.Instance.EventEmployee.OnEmployeeDeath += Event_EmployeeDeath;


    }

    private void OnDisable()
    {
        GameSceneManager.Instance.EventGameScene.OnDayEnd -= ClosePopup;
        EmployeeManager.Instance.EventEmployee.OnEmployeeDeath -= Event_EmployeeDeath;
    }

    private void Event_EmployeeDeath(EmployeeDeathEventArgs employeeDeathEventArgs)
    {
        if (employeeDeathEventArgs.index == _stats.Index)
        {
            ClosePopup();
        }
    }
    public void SetStat(EmployeeStats stat)
    {
        _stats = stat;
    }

    private void Update()
    {
        if (_stats == null)
            return;

        _nameText.text = _stats.Name;
        _abilityText.text = $"{_stats.Ability}/{_stats.MaxAbility}";
        _considerateText.text = $"{_stats.Considerate}/{_stats.MaxConsiderate}";
        _gutsText.text = $"{_stats.Guts}/{_stats.MaxGuts}";

        if (_stats.Ability == _stats.MaxAbility)
        {
            _abilityAmountText.text = "<color=black>Max";
            _abilityUpgradeButton.interactable = false;
        }
        else
        {
            _abilityAmountText.text = "$" + ((_stats.Ability + 1) * 100).ToString();
        }
        if (_stats.Considerate == _stats.MaxConsiderate)
        {
            _considerateAmountText.text = "<color=black>Max";
            _considerateUpgradeButton.interactable = false;
        }
        else
        {
            _considerateAmountText.text = "$" + ((_stats.Considerate + 1) * 100).ToString();
        }
        if (_stats.Guts == _stats.MaxGuts)
        {
            _gutsAmountText.text = "<color=black>Max";
            _gutsUpgradeButton.interactable = false;
        }
        else
        {
            _gutsAmountText.text = "$" + ((_stats.Guts + 1) * 100).ToString();
        }
    }

    private void UpgradeAbility()
    {
        int amount = (_stats.Ability + 1) * 100;

        if (GameSceneManager.Instance.CurrentMoney >= amount)
        {
            _stats.Ability++;
            GameSceneManager.Instance.EventGameScene.CallMoneyChanged(-amount);
        }
    }

    private void UpgradeConsiderate()
    {
        int amount = (_stats.Considerate + 1) * 100;

        if (GameSceneManager.Instance.CurrentMoney >= amount)
        {
            _stats.Considerate++;
            GameSceneManager.Instance.EventGameScene.CallMoneyChanged(-amount);
        }
    }

    private void UpgradeGuts()
    {
        int amount = (_stats.Guts + 1) * 100;

        if (GameSceneManager.Instance.CurrentMoney >= amount)
        {
            _stats.Guts++;
            GameSceneManager.Instance.EventGameScene.CallMoneyChanged(-amount);
        }
    }

#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        _nameText = FindGameObjectInChildren<TextMeshProUGUI>("NameText");
        _abilityText = FindGameObjectInChildren<TextMeshProUGUI>("AbilityText");
        _abilityAmountText = FindGameObjectInChildren<TextMeshProUGUI>("AbilityAmountText");
        _abilityUpgradeButton = FindGameObjectInChildren<Button>("AbilityUpgradeButton");
        _considerateText = FindGameObjectInChildren<TextMeshProUGUI>("ConsiderateText");
        _considerateAmountText = FindGameObjectInChildren<TextMeshProUGUI>("ConsiderateAmountText");
        _considerateUpgradeButton = FindGameObjectInChildren<Button>("ConsiderateUpgradeButton");
        _gutsText = FindGameObjectInChildren<TextMeshProUGUI>("GutsText");
        _gutsAmountText = FindGameObjectInChildren<TextMeshProUGUI>("GutsAmountText");
        _gutsUpgradeButton = FindGameObjectInChildren<Button>("GutsUpgradeButton");
        _closeButton = FindGameObjectInChildren<Button>("CloseButton");
    }

#endif
}
