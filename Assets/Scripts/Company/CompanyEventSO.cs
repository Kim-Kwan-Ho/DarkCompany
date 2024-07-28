using UnityEngine;

public enum ECompanyPositiveEvent
{
    MoneyIncrease,
    MoneyIncreaseBuff,
    EmployeeStressDecrease,
}

public enum ECompanyNegativeEvent
{
    MoneyDecrease,
    MoneyDecreaseBuff,
    EmployeeStressIncrease
}

public class CompanyEventSO : ScriptableObject
{
    public int MinRange;
    public int MaxRange;
    protected int _amount;
    public virtual void ActivateEvent()
    {

    }
}
