using UnityEngine;

public class EventGenerator : BaseBehaviour
{

    [SerializeField] private PositiveEventSo[] _companyPositiveEvents;
    [SerializeField] private NegativeEventSo[] _companyNegativeEvents;

    private void OnEnable()
    {
        GameSceneManager.Instance.EventGameScene.OnNewDayStart += Event_OnNewDayStart;
    }

    private void OnDisable()
    {
        GameSceneManager.Instance.EventGameScene.OnNewDayStart -= Event_OnNewDayStart;
    }

    private void Event_OnNewDayStart()
    {
        if (GameSceneManager.Instance.Day == 0)
            return;
        if (CheckCompanyEvent())
        {
            GenerateCompanyEvent();
        }
    }

    private bool CheckCompanyEvent()
    {
        int p = Random.Range(1, 101);

        if (p <= GameProbability.EVENT_COMPANY_APPEARANCE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void GenerateCompanyEvent()
    {
        int p = Random.Range(1, 101);

        p += (UpgradeManager.Instance.Luck * 5);
        if (p <= GameProbability.EVENT_COMPANY_POSITIVE)
        {
            // ºÎÁ¤Àû     
            int c = Random.Range(0, _companyNegativeEvents.Length);
            _companyNegativeEvents[c].ActivateEvent();
        }
        else
        {
            int c = Random.Range(0, _companyPositiveEvents.Length);
            _companyPositiveEvents[c].ActivateEvent();
        }
    }
}

