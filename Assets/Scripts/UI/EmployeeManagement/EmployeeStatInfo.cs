using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeStatInfo : UIPopup
{
    [SerializeField] private EmployeeStats _stats;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _stressText;
    [SerializeField] private TextMeshProUGUI _skillsText;
    [SerializeField] private TextMeshProUGUI _abilityText;
    [SerializeField] private TextMeshProUGUI _considerateText;
    [SerializeField] private TextMeshProUGUI _gutsText;
    [SerializeField] private TextMeshProUGUI _payText;
    [SerializeField] private Button _leaveWorkButton;
    [SerializeField] private Button _fireButton;
    [SerializeField] private Button _closeButton;
    private int _index;

    protected override void Initialize()
    {
        base.Initialize();
        _closeButton.onClick.AddListener(ClosePopup);
    }

    private void OnEnable()
    {
        GameSceneManager.Instance.EventGameScene.OnRequestNewDay += ClosePopup;

        _fireButton.onClick.AddListener(FireEmployee);
        _fireButton.onClick.AddListener(ClosePopup);
        _leaveWorkButton.onClick.AddListener(LeaveWorkEmployee);
        _leaveWorkButton.onClick.AddListener(ClosePopup);
    }

    private void OnDisable()
    {
        GameSceneManager.Instance.EventGameScene.OnRequestNewDay -= ClosePopup;
    }

    public void SetStatInfo(EmployeeStats stats, int index)
    {
        _stats = stats;
        _index = index;
    }

    private void FireEmployee()
    {
        EmployeeManager.Instance.EventEmployee.CallEmployeeFired(_stats, _index);
        _stats = null;
    }

    private void LeaveWorkEmployee()
    {
        EmployeeManager.Instance.EventEmployee.CallEmployeeLeaveWork(_stats, GameSceneManager.Instance.GameTime, _index);
        _stats.IsSleeping = true;
    }
    private void Update()
    {
        _nameText.text = _stats.Name;
        _stressText.text = $"{_stats.Stress}/{GameRule.STRESS_MAX}";
        _abilityText.text = $"{_stats.Ability}/{_stats.MaxAbility}";
        _considerateText.text = $"{_stats.Considerate}/{_stats.MaxConsiderate}";
        _gutsText.text = $"{_stats.Guts}/{_stats.MaxGuts}";
        _payText.text = $"{_stats.Pay}$";
    }




#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        _nameText = FindGameObjectInChildren<TextMeshProUGUI>("NameText");
        _stressText = FindGameObjectInChildren<TextMeshProUGUI>("StressText");
        _skillsText = FindGameObjectInChildren<TextMeshProUGUI>("SkillsText");
        _abilityText = FindGameObjectInChildren<TextMeshProUGUI>("AbilityText");
        _considerateText = FindGameObjectInChildren<TextMeshProUGUI>("ConsiderateText");
        _gutsText = FindGameObjectInChildren<TextMeshProUGUI>("GutsText");
        _payText = FindGameObjectInChildren<TextMeshProUGUI>("PayText");
        _closeButton = FindGameObjectInChildren<Button>("CloseButton");
        _leaveWorkButton = FindGameObjectInChildren<Button>("LeaveWorkButton");
        _fireButton = FindGameObjectInChildren<Button>("FireButton");
    }
#endif

}
