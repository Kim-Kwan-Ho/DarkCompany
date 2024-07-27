using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeInfo : BaseBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _abilityText;
    [SerializeField] private TextMeshProUGUI _gutsText;
    [SerializeField] private TextMeshProUGUI _payText;
    [SerializeField] private TextMeshProUGUI _considerateText;
    [SerializeField] private Button _hireButton;

    private EmployeeStats _stats;

    protected override void Awake()
    {
        base.Awake();
        _hireButton.onClick.AddListener(HireEmployee);
    }

    public void SetInfo(EmployeeStats stats)
    {
        _nameText.text = stats.Name;
        _abilityText.text = stats.Ability + "/" + stats.MaxAbility;
        _gutsText.text = stats.Guts + "/" + stats.MaxGuts;
        _considerateText.text = stats.Considerate + "/" + stats.MaxConsiderate;
        _payText.text = stats.Pay.ToString();
        _stats = stats;
    }

    private void HireEmployee()
    {
        if (EmployeeManager.Instance.CanHireEmployee())
        {
            EmployeeManager.Instance.HireEmployee(_stats);
            Destroy(this.gameObject);
        }
    }



    protected override void OnBindField()
    {
        base.OnBindField();
        _nameText = FindGameObjectInChildren<TextMeshProUGUI>("NameText");
        _abilityText = FindGameObjectInChildren<TextMeshProUGUI>("AbilityText");
        _gutsText = FindGameObjectInChildren<TextMeshProUGUI>("GutsText");
        _payText = FindGameObjectInChildren<TextMeshProUGUI>("PayText");
        _considerateText = FindGameObjectInChildren<TextMeshProUGUI>("ConsiderateText");
        _hireButton = FindGameObjectInChildren<Button>("HireButton");
    }



}
