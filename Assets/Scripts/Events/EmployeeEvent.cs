using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeEvent : MonoBehaviour
{
    public Action<EmployeeHiredEventArgs> OnEmployeeHired;
    public Action<EmployeeFireEventArgs> OnEmployeeFired;
    public Action<EmployeeLeaveWorkEventArgs> OnEmployeeLeaveWork;
    public Action<EmployeeGoToWorkEventArgs> OnEmployeeGoToWork;
    public Action<EmployeeRequestPayEventArgs> OnEmployeeRequestPay;
    public Action<EmployeeStressedEventArgs> OnEmployeeStressed;
    public Action<EmployeeMadeMoneyEventArgs> OnEmployeeMadeMoney;
    public Action<EmployeeGetPayedEventArgs> OnEmployeeGetPayed;
    public Action<EmployeeDeathEventArgs> OnEmployeeDeath;
    public void CallEmployeeHired(EmployeeStats stat, int index)
    {
        OnEmployeeHired?.Invoke(new EmployeeHiredEventArgs() { stat = stat, index = index });
    }

    public void CallEmployeeFired(EmployeeStats stat, int index)
    {
        OnEmployeeFired?.Invoke(new EmployeeFireEventArgs() { stat = stat, index = index });
    }

    public void CallEmployeeLeaveWork(EmployeeStats stat, int time, int index)
    {
        OnEmployeeLeaveWork?.Invoke(new EmployeeLeaveWorkEventArgs() { stat = stat, time = time, index = index });
    }

    public void CallEmployeeGoToWork(int index)
    {
        OnEmployeeGoToWork?.Invoke(new EmployeeGoToWorkEventArgs() { index = index });
    }
    public void CallEmployeeRequestPay(int index)
    {
        OnEmployeeRequestPay?.Invoke(new EmployeeRequestPayEventArgs() { index = index });
    }

    public void CallEmployeeStressed(int index, int amount)
    {
        OnEmployeeStressed?.Invoke(new EmployeeStressedEventArgs() { index = index, amount = amount });
    }

    public void CallEmployeeMadeMoney(int index, int amount)
    {
        OnEmployeeMadeMoney?.Invoke(new EmployeeMadeMoneyEventArgs() { index = index, amount = amount });
    }

    public void CallEmployeeGetPayed(int index)
    {
        OnEmployeeGetPayed?.Invoke(new EmployeeGetPayedEventArgs() { index = index });
    }

    public void CallEmployeeDeath(int index)
    {
        OnEmployeeDeath?.Invoke(new EmployeeDeathEventArgs() { index = index });
    }
}


public class EmployeeHiredEventArgs : EventArgs
{
    public EmployeeStats stat;
    public int index;
}

public class EmployeeFireEventArgs : EventArgs
{
    public EmployeeStats stat;
    public int index;
}
public class EmployeeLeaveWorkEventArgs : EventArgs
{
    public EmployeeStats stat;
    public int time;
    public int index;
}

public class EmployeeRequestPayEventArgs : EventArgs
{
    public int index;
}

public class EmployeeStressedEventArgs : EventArgs
{
    public int index;
    public int amount;
}

public class EmployeeMadeMoneyEventArgs : EventArgs
{
    public int index;
    public int amount;
}

public class EmployeeGoToWorkEventArgs : EventArgs
{
    public int index;
}

public class EmployeeGetPayedEventArgs : EventArgs
{
    public int index;
}

public class EmployeeDeathEventArgs : EventArgs
{
    public int index;
}