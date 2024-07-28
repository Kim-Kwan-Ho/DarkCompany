using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(EmployeeEmoji))]
public class Employee : BaseBehaviour
{
    [Header("Property")]
    [SerializeField] private string _name;
    [SerializeField] private int _level;
    [SerializeField] private int _pay;
    [SerializeField] private int _curStress;
    [SerializeField] private int _workManagement;
    [SerializeField] private int _workSpeed;
    [SerializeField] private EmployeeSkill[] _skills;
    private int _payTime;
    private bool _stressSkillCreated;


    [Header("UI")]
    [SerializeField] private EmployeeEmoji _emoji;


    protected override void Initialize()
    {
        base.Initialize();
        _payTime = Random.Range(GameRule.PAY_TIME_MIN, GameRule.PAY_TIME_MAX);
        _curStress = GameRule.STRESS_MIN;
        _stressSkillCreated = false;
    }

    private void OnEnable()
    {
        GameSceneManager.Instance.EventGameScene.OnTimeChanged += Event_OnTimeChanged;
    }

    private void OnDisable()
    {
        GameSceneManager.Instance.EventGameScene.OnTimeChanged -= Event_OnTimeChanged;
    }

    private void RequestPay()
    {
        _emoji.CreateEmoji(EEmojiType.RequestMoney);
    }

    public void GetPayed()
    {
        if (GameSceneManager.Instance.CurrentMoney >= _pay)
        {
            GameSceneManager.Instance.EventGameScene.CallMoneyChanged(-_pay);
        }
    }
    private void Event_OnTimeChanged()
    {
        if (_payTime > 0)
        {
            _payTime--;
            if (_payTime == 0)
            {
                RequestPay();
            }
        }
        else
        {
            AddStress();
        }
    }
    private void AddStress()
    {
        _curStress = Math.Min(_curStress + Random.Range(GameProbability.STRESS_INCREASE_MIN, GameProbability.STRESS_INCREASE_MAX), 200);
        
        CheckStress();
    }
    private void CheckStress()
    {
        if (_curStress >= GameRule.STRESS_SKILL_CREATEGAGE && !_stressSkillCreated)
        {
            // ·£´ý ½ºÅ³ »ý¼º (ºØ±« È¤Àº °¢¼º)
            _stressSkillCreated = true;
        }
        if (_curStress >= GameRule.STRESS_MAX)
        {
            _curStress = GameRule.STRESS_MAX;
            EmployeeDeath();
        }
        else
        {
            _emoji.CreateEmoji(EEmojiType.Stressed);
        }
    }

    private void EmployeeDeath()
    {
        Destroy(this.gameObject);
    }
    private void Event_EmployeeDeath()
    {

    }

    public void UpgradeEmployee()
    {
    }

    public void ChangeEmployeeSkill()
    {

    }

    public void LeaveWork()
    {
    }


#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        _emoji = GetComponent<EmployeeEmoji>();
    }

#endif
}

