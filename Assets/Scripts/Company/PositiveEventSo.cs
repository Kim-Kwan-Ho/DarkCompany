using UnityEngine;

[CreateAssetMenu(fileName = "PositiveCompanyEvent_", menuName = "Scriptable Objects/Events/CompanyPositiveEvent")]
public class PositiveEventSo : CompanyEventSO
{
    public ECompanyPositiveEvent EventType;

    public override void ActivateEvent()
    {
        _amount = Random.Range(MinRange, MaxRange);
        switch (EventType)
        {
            case ECompanyPositiveEvent.MoneyIncrease:
                GameSceneManager.Instance.EventGameScene.CallMoneyChanged(_amount);
                UIManager.Instance.OpenEventPopup($"바닥에 떨어진 돈을 주워 {_amount}의 금액을 획득하였습니다.");
                break;
            case ECompanyPositiveEvent.MoneyIncreaseBuff:
                EmployeeManager.Instance.PayBuff = _amount;
                UIManager.Instance.OpenEventPopup($"정부의 지원을 받아 하루동안 벌어들이는 수익이 {_amount}% 증가합니다.");
                break;
            case ECompanyPositiveEvent.EmployeeStressDecrease:
                EmployeeManager.Instance.InDeCreaseEmployeesStress(false, _amount);
                UIManager.Instance.OpenEventPopup($"좋은 날씨로 인해 직원들의 스트레스 수치가 {_amount}만큼 감소하였습니다.");
                break;
        }
    }
}