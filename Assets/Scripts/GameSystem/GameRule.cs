using UnityEngine;

public static class GameRule
{

    public const int TIME_FOR_REALTIME = 1;
    public const int COMPANY_OPEN_TIME = 9;
    public const int COMPANY_CLOSE_TIME = 24;
    public const int COMPANY_LEAVE_TIME = 18;
    public const int STRESS_MAX = 200;
    public const int STRESS_MIN = 0;
    public const int STRESS_SKILL_CREATEGAGE = 100;
    public const int STRESS_DECREASE_AMOUNT = 10;
    public const int PAY_TIME_MAX = 6;
    public const int PAY_TIME_MIN = 3;
    public const int MAX_EMPLOYEE_COUNT = 6;


    public const int COMPANY_START_MONEY = 1000;
    public const int COMPANY_CHARGE_INCREASE = 100;

}


public static class GameProbability
{
    public const int STRESS_INCREASE_MIN = 4;
    public const int STRESS_INCREASE_MAX = 10;

    public const int EMPLOYEE_START_STATS_MAX = 9;
    public const int EMPLOYEE_START_STATS_MIN = 4;

    public const int EMPLOYEE_MAX_STATS_MAX = 9;
    public const int EMPLOYEE_MAX_STATS_MIN = 6;

    public const int EMPLOYEE_START_PAY_MIN = 100;
    public const int EMPLOYEE_START_PAY_MAX = 300;

    public const int EVENT_COMPANY_APPEARANCE = 30;
    public const int EVENT_COMPANY_POSITIVE = 60;


}


public static class GameColor
{
    public static Color MONEY_GREEN = Color.green;
    public static Color MONEY_RED = Color.red;
}

public static class Names
{
    public static readonly string[] LAST_NAME = new string[]
    {
        "��", "��", "��", "��", "��", "��", "��",
         "��", "��", "��", "��", "��", "��", "��", "��",
        "��","��","��","��", "��","ġ","��","��","��","��","��","��","��","��"
    };
    public static readonly string[] FIRST_NAME = new string[] { "��", "��", "��", "��", "��", "��", "��", "��" };
}

public static class UpgradeCosts
{
    public static readonly int[] UPGRADE_COST = new int[4] { 100, 200, 300, 400 };

}