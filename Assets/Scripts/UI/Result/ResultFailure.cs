using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultFailure : BaseBehaviour
{
    [SerializeField] private TextMeshProUGUI _dayText;
    [SerializeField] private TextMeshProUGUI _currentMoneyText;
    [SerializeField] private TextMeshProUGUI _chargeText;
    [SerializeField] private TextMeshProUGUI _totalMoneyText;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _retryButton;


    protected override void Initialize()
    {
        base.Initialize();
        _exitButton.onClick.AddListener(ExitGame);
        _retryButton.onClick.AddListener(RetryGame);
    }

    public void SetResult(int day, int currentMoney, int charge)
    {
        _dayText.text = day.ToString();
        _currentMoneyText.text = currentMoney.ToString();
        _chargeText.text = charge.ToString();
        int totalMoney = currentMoney - charge;
        _totalMoneyText.text = "- " + totalMoney.ToString();
    }


    private void ExitGame()
    {
        Application.Quit();
    }

    private void RetryGame() // 이것도 나중에 바꿔야함
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        _dayText = FindGameObjectInChildren<TextMeshProUGUI>("DayText");
        _currentMoneyText = FindGameObjectInChildren<TextMeshProUGUI>("CurrentMoneyText");
        _chargeText = FindGameObjectInChildren<TextMeshProUGUI>("ChargeText");
        _totalMoneyText = FindGameObjectInChildren<TextMeshProUGUI>("TotalMoneyText");
        _exitButton = FindGameObjectInChildren<Button>("ExitButton");
        _retryButton = FindGameObjectInChildren<Button>("RetryButton");
    }

#endif
}
