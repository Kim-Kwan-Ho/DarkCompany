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
                UIManager.Instance.OpenEventPopup($"�ٴڿ� ������ ���� �ֿ� {_amount}�� �ݾ��� ȹ���Ͽ����ϴ�.");
                break;
            case ECompanyPositiveEvent.MoneyIncreaseBuff:
                EmployeeManager.Instance.PayBuff = _amount;
                UIManager.Instance.OpenEventPopup($"������ ������ �޾� �Ϸ絿�� ������̴� ������ {_amount}% �����մϴ�.");
                break;
            case ECompanyPositiveEvent.EmployeeStressDecrease:
                EmployeeManager.Instance.InDeCreaseEmployeesStress(false, _amount);
                UIManager.Instance.OpenEventPopup($"���� ������ ���� �������� ��Ʈ���� ��ġ�� {_amount}��ŭ �����Ͽ����ϴ�.");
                break;
        }
    }
}