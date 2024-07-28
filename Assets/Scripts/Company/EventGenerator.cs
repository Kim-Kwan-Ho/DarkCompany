using UnityEngine;

public class EventGenerator : BaseBehaviour
{

    [SerializeField] private CompanyEventSO[] _companyEvents; 
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
        _companyEvents[0].ActivateEvent();

        //if (CheckCompanyEvent())
        //{
        //    GenerateCompanyEvent();
        //}
        //if (GameSceneManager.Instance.Day == 0)
        //    return;
    }

    private bool CheckCompanyEvent()
    {
        int p = Random.Range(1, 101);

        if (p >= GameProbability.EVENT_COMPANY_APPEARANCE)
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
        _companyEvents[0].ActivateEvent();
        if (p >= GameProbability.EVENT_COMPANY_POSITIVE)
        {
            
        }
        else
        {
            
        }
    }
}

