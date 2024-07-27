using System;
using UnityEngine;

public class UpgradeEvent : MonoBehaviour
{
    public Action OnCompanyUpgrade;
    public Action OnItemUpgrade;
    public Action OnRecruitUpgrade;

    public void CallCompanyUpgraded()
    {
        OnCompanyUpgrade?.Invoke();
    }

    public void CallItemUpgraded()
    {
        OnItemUpgrade?.Invoke();
    }

    public void CallRecruitUpgraded()
    {
        OnRecruitUpgrade?.Invoke();
    }

}
