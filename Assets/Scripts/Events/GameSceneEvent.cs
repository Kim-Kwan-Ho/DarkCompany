using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneEvent : MonoBehaviour
{
    public Action OnNewDayStart;
    public Action OnDayEnd;
    public Action OnRequestNewDay;


    public Action OnTimeStopped;
    public Action OnTimeChanged;

    public Action<int> OnMoneyChanged;
    public void CallNewDayStart()
    {
        OnNewDayStart?.Invoke();
    }

    public void CallOnDayEnd()
    {
        OnDayEnd?.Invoke();
    }

    public void CallTimeChanged()
    {
        OnTimeChanged?.Invoke();
    }

    public void CallTimeStopped()
    {
        OnTimeStopped?.Invoke();
    }

    public void CallMoneyChanged(int amount)
    {
        OnMoneyChanged?.Invoke(amount);
    }

    public void CallRequestNewDay()
    {
        OnRequestNewDay?.Invoke();
    }
}



