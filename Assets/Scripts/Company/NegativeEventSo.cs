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
                UIManager.Instance.OpenEventPopup($"��⸦ ���� {_amount}�� �ݾ��� ���غý��ϴ�.");
                break;
            case ECompanyNegativeEvent.MoneyDecreaseBuff:
                EmployeeManager.Instance.PayBuff = -_amount;
                UIManager.Instance.OpenEventPopup($"�ǹ� ����� ���� ���꼺�� ���ҵǾ� ������ {_amount}% �����մϴ�.");
                break;
            case ECompanyNegativeEvent.EmployeeStressIncrease:
                EmployeeManager.Instance.InDeCreaseEmployeesStress(true, _amount);
                UIManager.Instance.OpenEventPopup($"���� ������ ���� �������� ��Ʈ���� ��ġ�� {_amount}��ŭ �����Ͽ����ϴ�.");
                break;
        }
    }

}