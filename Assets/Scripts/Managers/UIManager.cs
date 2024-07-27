using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : BaseBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject _popupCanvas;
    private Stack<UIPopup> _popupStack;


    [SerializeField] private GameObject _noticePopup;
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
        _popupStack = new Stack<UIPopup>();
    }

    private void OnEnable()
    {
        GameSceneManager.Instance.EventGameScene.OnRequestNewDay += Event_CloseAllPopup;
        GameSceneManager.Instance.EventGameScene.OnDayEnd += Event_CloseAllPopup;
    }

    private void OnDisable()
    {
        GameSceneManager.Instance.EventGameScene.OnRequestNewDay -= Event_CloseAllPopup;
        GameSceneManager.Instance.EventGameScene.OnDayEnd -= Event_CloseAllPopup;
    }

    private void Event_CloseAllPopup()
    {
        CloseAllPopup();
    }

    public void OpenPopup<T>() where T : UIPopup
    {
        Type t = typeof(T);
        GameObject gob = Resources.Load<GameObject>("UI/" + t.Name);

        UIPopup popup = Instantiate(gob, _popupCanvas.transform).GetComponent<UIPopup>();
        popup.transform.localScale = new Vector3(1, 1, 1);
        _popupStack.Push(popup);
    }


    public void OpenNoticePopup(string text)
    {
        NoticePopup popup = Instantiate(_noticePopup, _popupCanvas.transform).GetComponent<NoticePopup>();
        popup.transform.localScale = new Vector3(1, 1, 1);
        popup.SetText(text);
        _popupStack.Push(popup);
    }

    public void OpenTimeScaleNotice(string text)
    {

    }
    public void CloseAllPopup()
    {
        while (_popupStack.Count > 0)
        {
            if (_popupStack.Peek() != null)
            {
                _popupStack.Pop().ClosePopup();
            }
            else
            {
                _popupStack.Pop();
            }
        }
    }






#if UNITY_EDITOR

    protected override void OnBindField()
    {
        base.OnBindField();
        _noticePopup = Resources.Load<GameObject>("UI/NoticePopup");
        _popupCanvas = GameObject.Find("PopupCanvas");
    }

    protected override void OnButtonField()
    {
        base.OnButtonField();
        GameObject gob = Resources.Load<GameObject>("UI/" + "EmployeeManagement");
        Debug.Log(gob.name);

    }

#endif
}
