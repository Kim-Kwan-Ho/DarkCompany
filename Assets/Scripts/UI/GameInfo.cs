using TMPro;
using UnityEngine;

public class GameInfo : BaseBehaviour
{
    [Header("Time Texts")]
    [SerializeField] private TextMeshProUGUI _dayText;
    [SerializeField] private TextMeshProUGUI _timeText;

    [Header("Money Texts")]
    [SerializeField] private TextMeshProUGUI _incomeText;
    [SerializeField] private TextMeshProUGUI _chargeText;
    [SerializeField] private TextMeshProUGUI _moneyText;




    private void Update()
    {
        _dayText.text = GameSceneManager.Instance.Day.ToString();
        _timeText.text = GameSceneManager.Instance.GameTime.ToString("D2") + ":00";
        _incomeText.text = GameSceneManager.Instance.TodayIncome.ToString();
        _chargeText.text = GameSceneManager.Instance.Charge.ToString();
        _moneyText.text = GameSceneManager.Instance.CurrentMoney.ToString();


    }



#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        _dayText = FindGameObjectInChildren<TextMeshProUGUI>("DayText");
        _timeText = FindGameObjectInChildren<TextMeshProUGUI>("TimeText");

        _incomeText = FindGameObjectInChildren<TextMeshProUGUI>("IncomeText");
        _chargeText = FindGameObjectInChildren<TextMeshProUGUI>("ChargeText");
        _moneyText = FindGameObjectInChildren<TextMeshProUGUI>("MoneyText");
    }

#endif



}
