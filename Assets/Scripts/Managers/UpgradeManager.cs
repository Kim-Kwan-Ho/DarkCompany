using UnityEngine;
[RequireComponent(typeof(UpgradeEvent))]
public class UpgradeManager : BaseBehaviour
{
    public static UpgradeManager Instance;
    public UpgradeEvent EventUpgrade;


    private int _companyLevel;
    public int CompanyLevel { get { return _companyLevel; } }
    private int _recruitLevel;
    public int RecruitLevel { get { return _recruitLevel; } }
    private int _itemLevel;
    public int ItemLevel { get { return _itemLevel; } }

    public int Luck;

    public int Loyalty;


    public int FlowerCount;
    protected override void Awake()
    {
        base.Awake();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }
    }

    protected override void Initialize()
    {
        base.Initialize();
        _companyLevel = 1;
        _itemLevel = 1;
        _recruitLevel = 1;
        Luck = 0;
        Loyalty = 0;
        FlowerCount = 0;
    }

    private void OnEnable()
    {
        EventUpgrade.OnCompanyUpgrade += Event_CompanyLevelUpgrade;
        EventUpgrade.OnRecruitUpgrade += Event_RecruitLevelUpgrade;
        EventUpgrade.OnItemUpgrade += Event_ItemLevelUpgrade;
    }

    private void OnDisable()
    {
        EventUpgrade.OnCompanyUpgrade -= Event_CompanyLevelUpgrade;
        EventUpgrade.OnRecruitUpgrade -= Event_RecruitLevelUpgrade;
        EventUpgrade.OnItemUpgrade -= Event_ItemLevelUpgrade;
    }
    private void Event_CompanyLevelUpgrade()
    {
        _companyLevel++;
    }
    private void Event_ItemLevelUpgrade()
    {
        _itemLevel++;
    }
    private void Event_RecruitLevelUpgrade()
    {
        _recruitLevel++;
    }


#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        EventUpgrade = GetComponent<UpgradeEvent>();
    }
#endif
}
