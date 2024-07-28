using UnityEngine;

[CreateAssetMenu(fileName = "NegativeCompanyEvent_", menuName = "Scriptable Objects/Events/CompanyNegativeEvent")]
public class NegativeEventSo : CompanyEventSO
{
    public ECompanyNegativeEvent EventType;

    public override void ActivateEvent()
    {
        _amount = Random.Range(MinRange, MaxRange);
        switch (EventType)
        {
            case ECompanyNegativeEvent.MoneyDecrease:
                GameSceneManager.Instance.EventGameScene.CallMoneyChanged(_amount);
                UIManager.Instance.OpenEventPopup($"사기를 당해 {_amount}의 금액을 손해봤습니다.");
                break;
            case ECompanyNegativeEvent.MoneyDecreaseBuff:
                EmployeeManager.Instance.PayBuff = -_amount;
                UIManager.Instance.OpenEventPopup($"건물 공사로 인해 생산성이 감소되어 수익이 {_amount}% 감소합니다.");
                break;
            case ECompanyNegativeEvent.EmployeeStressIncrease:
                EmployeeManager.Instance.InDeCreaseEmployeesStress(true, _amount);
                UIManager.Instance.OpenEventPopup($"더운 날씨로 인해 직원들의 스트레스 수치가 {_amount}만큼 증가하였습니다.");
                break;
        }
    }

}