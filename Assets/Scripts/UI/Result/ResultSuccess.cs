using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultSuccess : BaseBehaviour
{
    [SerializeField] private TextMeshProUGUI _dayText;
    [SerializeField] private TextMeshProUGUI _incomeText;
    [SerializeField] private TextMeshProUGUI _chargeText;
    [SerializeField] private TextMeshProUGUI _totalMoneyText;
    [SerializeField] private Button _confirmButton;

    protected override void Initialize()
    {
        base.Initialize();
        _confirmButton.onClick.AddListener(Confirm);
    }

    public void SetResult(int day, int income, int charge)
    {
        _dayText.text = day.ToString() + "ÀÏÂ÷";
        _incomeText.text = "+ " + income.ToString();
        _chargeText.text = "- " + charge.ToString();

        int totalMoney = income - charge;
        _totalMoneyText.color = totalMoney >= 0 ? GameColor.MONEY_GREEN : GameColor.MONEY_RED;
        _totalMoneyText.text += totalMoney >= 0 ? "+ " :"";

        _totalMoneyText.text += totalMoney.ToString();
    }

    private void Confirm()
    {
        GameSceneManager.Instance.EventGameScene.CallRequestNewDay();
        Destroy(this.gameObject);
    }


#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        _dayText = FindGameObjectInChildren<TextMeshProUGUI>("DayText");
        _incomeText = FindGameObjectInChildren<TextMeshProUGUI>("IncomeText");
        _chargeText = FindGameObjectInChildren<TextMeshProUGUI>("ChargeText");
        _totalMoneyText = FindGameObjectInChildren<TextMeshProUGUI>("TotalMoneyText");
        _confirmButton = FindGameObjectInChildren<Button>("ConfirmButton");

    }
#endif

}
