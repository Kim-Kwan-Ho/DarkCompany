using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OfficeUpgradePopup : UIPopup
{
    [Header("Company")]
    [SerializeField] private Button _companyUpgradeButton;
    [SerializeField] private TextMeshProUGUI _companyLevelText;
    [SerializeField] private TextMeshProUGUI _companyCostText;

    [Header("Item")]
    [SerializeField] private Button _itemUpgradeButton;
    [SerializeField] private TextMeshProUGUI _itemLevelText;
    [SerializeField] private TextMeshProUGUI _itemCostText;

    [Header("Recruit")]
    [SerializeField] private Button _recruitUpgradeButton;
    [SerializeField] private TextMeshProUGUI _recruitLevelText;
    [SerializeField] private TextMeshProUGUI _recruitCostText;

    [Header("Others")]
    [SerializeField] private Button _closeButton;


    protected override void Awake()
    {
        base.Awake();
        _closeButton.onClick.AddListener(ClosePopup);
        _companyUpgradeButton.onClick.AddListener(UpgradeCompany);
        _itemUpgradeButton.onClick.AddListener(UpgradeItem);
        _recruitUpgradeButton.onClick.AddListener(UpgradeRecruit);
    }

    private void Update()
    {
        _companyLevelText.text = "Lv." + UpgradeManager.Instance.CompanyLevel.ToString();
        if (UpgradeManager.Instance.CompanyLevel >= 3)
        {
            _companyCostText.text = "Max";
            _companyUpgradeButton.interactable = false;
        }
        else
        {
            _companyCostText.text = UpgradeCosts.UPGRADE_COST[UpgradeManager.Instance.CompanyLevel].ToString() + " $";
        }


        _itemLevelText.text = "Lv." + UpgradeManager.Instance.ItemLevel.ToString();
        if (UpgradeManager.Instance.ItemLevel >= 3)
        {
            _itemCostText.text = "Max";
            _itemUpgradeButton.interactable = false;
        }
        else
        {
            _itemCostText.text = UpgradeCosts.UPGRADE_COST[UpgradeManager.Instance.ItemLevel].ToString() + " $";
        }
        _recruitLevelText.text = "Lve." + UpgradeManager.Instance.RecruitLevel.ToString();
        if (UpgradeManager.Instance.RecruitLevel >= 3)
        {
            _recruitCostText.text = "Max";
            _recruitUpgradeButton.interactable = false;
        }
        else
        {
            _recruitCostText.text = UpgradeCosts.UPGRADE_COST[UpgradeManager.Instance.RecruitLevel].ToString() + " $";
        }
    }
    private void UpgradeCompany()
    {
        if (GameSceneManager.Instance.CurrentMoney >= UpgradeCosts.UPGRADE_COST[UpgradeManager.Instance.CompanyLevel])
        {
            GameSceneManager.Instance.EventGameScene.CallMoneyChanged(-UpgradeCosts.UPGRADE_COST[UpgradeManager.Instance.CompanyLevel]);
            UpgradeManager.Instance.EventUpgrade.CallCompanyUpgraded();
        }
        else
        {
            UIManager.Instance.OpenNoticePopup("돈이 부족합니다.");
        }
    }

    private void UpgradeItem()
    {
        if (GameSceneManager.Instance.CurrentMoney >= UpgradeCosts.UPGRADE_COST[UpgradeManager.Instance.ItemLevel])
        {
            GameSceneManager.Instance.EventGameScene.CallMoneyChanged(-UpgradeCosts.UPGRADE_COST[UpgradeManager.Instance.ItemLevel]);
            UpgradeManager.Instance.EventUpgrade.CallItemUpgraded();
        }
        else
        {
            UIManager.Instance.OpenNoticePopup("돈이 부족합니다.");
        }
    }

    private void UpgradeRecruit()
    {
        if (GameSceneManager.Instance.CurrentMoney >= UpgradeCosts.UPGRADE_COST[UpgradeManager.Instance.RecruitLevel])
        {
            GameSceneManager.Instance.EventGameScene.CallMoneyChanged(-UpgradeCosts.UPGRADE_COST[UpgradeManager.Instance.RecruitLevel]);
            UpgradeManager.Instance.EventUpgrade.CallRecruitUpgraded();
        }
        else
        {
            UIManager.Instance.OpenNoticePopup("돈이 부족합니다.");
        }
    }

#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        _companyUpgradeButton = FindGameObjectInChildren<Button>("CompanyUpgradeButton");
        _companyLevelText = FindGameObjectInChildren<TextMeshProUGUI>("CompanyLevelText");
        _companyCostText = FindGameObjectInChildren<TextMeshProUGUI>("CompanyCostText");

        _itemUpgradeButton = FindGameObjectInChildren<Button>("ItemUpgradeButton");
        _itemLevelText = FindGameObjectInChildren<TextMeshProUGUI>("ItemLevelText");
        _itemCostText = FindGameObjectInChildren<TextMeshProUGUI>("ItemCostText");

        _recruitUpgradeButton = FindGameObjectInChildren<Button>("RecruitUpgradeButton");
        _recruitLevelText = FindGameObjectInChildren<TextMeshProUGUI>("RecruitLevelText");
        _recruitCostText = FindGameObjectInChildren<TextMeshProUGUI>("RecruitCostText");

        _closeButton = FindGameObjectInChildren<Button>("CloseButton");
    }
#endif
}
