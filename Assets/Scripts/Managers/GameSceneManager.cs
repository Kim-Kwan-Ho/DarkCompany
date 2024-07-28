using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(GameSceneEvent))]
public class GameSceneManager : BaseBehaviour
{
    public static GameSceneManager Instance;
    public GameSceneEvent EventGameScene;


    [Header("Date & Time")]
    private int _day;
    public int Day { get { return _day; } }
    private float _realTime;
    private int _gameTime;
    public int GameTime { get { return _gameTime; } }



    [Header("Money")]
    private int _currentMoney;

    public int CurrentMoney { get { return _currentMoney; } }
    private int _charge;

    public int Charge { get { return _charge; } }
    private int _todayIncome;
    public int TodayIncome { get { return _todayIncome; } }

    [Header("Game Property")]
    private bool _gameStopped;




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
        _gameTime = GameRule.COMPANY_OPEN_TIME;
        _realTime = 0;
        _charge = GameRule.COMPANY_CHARGE_INCREASE;
        _currentMoney = GameRule.COMPANY_START_MONEY;
        _gameStopped = true;
    }

    private void Start()
    {
        EventGameScene.CallNewDayStart();
    }
    private void OnEnable()
    {
        EventGameScene.OnTimeStopped += Event_TimeStopped;
        EventGameScene.OnTimeChanged += Event_TImeChanged;
        EventGameScene.OnDayEnd += Event_OnDayEnd;
        EventGameScene.OnMoneyChanged += Event_MoneyChanged;
        EventGameScene.OnNewDayStart += Event_OnNewDayStart;
        EventGameScene.OnRequestNewDay += Event_OnRequestNewDay;
    }
    private void OnDisable()
    {
        EventGameScene.OnTimeStopped -= Event_TimeStopped;
        EventGameScene.OnTimeChanged -= Event_TImeChanged;
        EventGameScene.OnDayEnd -= Event_OnDayEnd;
        EventGameScene.OnMoneyChanged -= Event_MoneyChanged;
        EventGameScene.OnNewDayStart -= Event_OnNewDayStart;
        EventGameScene.OnRequestNewDay -= Event_OnRequestNewDay;
    }
    private void Update()
    {
        TimeSystem();
    }

    private void TimeSystem()
    {
        if (_gameStopped)
            return;

        _realTime += Time.deltaTime;
        if (_realTime >= GameRule.TIME_FOR_REALTIME)
        {
            _realTime = 0;
            EventGameScene.CallTimeChanged();
        }
    }

    private void Event_TImeChanged()
    {
        _gameTime++;
        if (_gameTime >= GameRule.COMPANY_CLOSE_TIME)
        {
            EventGameScene.CallOnDayEnd();
        }
    }
    private void Event_TimeStopped()
    {
        _gameStopped = true;
    }

    private void Event_OnDayEnd()
    {
        _gameStopped = true;
    }

    private void Event_OnRequestNewDay()
    {
        _day++;
        _todayIncome = 0;
        _currentMoney -= _charge;
        _charge += GameRule.COMPANY_CHARGE_INCREASE;
        _gameTime = GameRule.COMPANY_OPEN_TIME;
    }
    private void Event_MoneyChanged(int amount)
    {
        _currentMoney += amount;
        if (amount >= 0)
            _todayIncome += amount;

    }
    private void Event_OnNewDayStart()
    {
        _gameStopped = false;
    }
#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        EventGameScene = GetComponent<GameSceneEvent>();
    }
#endif

}
