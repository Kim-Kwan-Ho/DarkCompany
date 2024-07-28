
using UnityEngine;
using UnityEngine.UI;

public class EmployeeManagement : UIPopup
{
    [SerializeField] private Button _employButton;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _skillChangeButton;
    [SerializeField] private Button _closeButton;


    protected override void Initialize()
    {
        base.Initialize();
        _closeButton.onClick.AddListener(ClosePopup);
        _employButton.onClick.AddListener(OpenEmployPopup);
        _employButton.onClick.AddListener(ClosePopup);
        _skillChangeButton.onClick.AddListener(OpenSkillChangePopup);
        _skillChangeButton.onClick.AddListener(ClosePopup);
    }



    private void OpenEmployPopup()
    {
        UIManager.Instance.OpenPopup<EmployPopup>();
    }

    private void OpenSkillChangePopup()
    {
        UIManager.Instance.OpenPopup<SkillAddPopup>();
    }






#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        _employButton = FindGameObjectInChildren<Button>("EmployButton");
        _upgradeButton = FindGameObjectInChildren<Button>("UpgradeButton");
        _skillChangeButton = FindGameObjectInChildren<Button>("SkillChangeButton");
        _closeButton = FindGameObjectInChildren<Button>("CloseButton");
    }

#endif









}
