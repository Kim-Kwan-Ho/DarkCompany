
using UnityEngine;
using UnityEngine.UI;

public class EmployPopup : UIPopup
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private GameObject _verticalGroup;
    [SerializeField] private GameObject _employeeInfo;

    protected override void Awake()
    {
        base.Awake();
        CreateEmployeeInfo();
    }

    protected override void Initialize()
    {
        base.Initialize();
        _closeButton.onClick.AddListener(ClosePopup);
    }

    public void CreateEmployeeInfo()
    {
        foreach (var e in EmployeeManager.Instance.NewEmployees)
        {
            EmployeeInfo info = Instantiate(_employeeInfo, _verticalGroup.transform).GetComponent<EmployeeInfo>();
            info.SetInfo(e);
        }

    }


#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        _closeButton = FindGameObjectInChildren<Button>("CloseButton");
        _verticalGroup = FindGameObjectInChildren("VerticalGroup");
        _employeeInfo = Resources.Load<GameObject>("UI/EmployeeInfo");
    }

#endif
}
