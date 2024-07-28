using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UIManager : BaseBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject _popupCanvas;
    private Stack<UIPopup> _popupStack;


    [SerializeField] private GameObject _noticePopup;
    [SerializeField] private GameObject _warningPopup;
    [SerializeField] private GameObject _eventPopup;
    [SerializeField] private GameObject _worldCanvas;
    [SerializeField] private GameObject _changeText;

    private int _warningCount;
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
        _warningCount = 0;
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

    public void OpenWarningPopup(string text)
    {
        Time.timeScale = 0;
        WarningPopup popup = Instantiate(_warningPopup, _popupCanvas.transform).GetComponent<WarningPopup>();
        popup.transform.localScale = new Vector3(1, 1, 1);
        popup.SetText(text);
        _warningCount++;
    }

    public void OpenEventPopup(string text)
    {
        Time.timeScale = 0;
        WarningPopup popup = Instantiate(_eventPopup, _popupCanvas.transform).GetComponent<WarningPopup>();
        popup.transform.localScale = new Vector3(1, 1, 1);
        popup.SetText(text);
        _warningCount++;
    }
    public void CloseWarningPopup()
    {
        _warningCount--;

        if (_warningCount <= 0)
        {
            _warningCount = 0;
            Time.timeScale = 1;
        }
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

    public void InstantiateChangeText(string info, Color color, Vector3 position)
    {
        ChangeText text = Instantiate(_changeText, _worldCanvas.transform).GetComponent<ChangeText>();
        if (color == Color.red)
        {
            text.SetText(position + new Vector3(0, Random.Range(0f, 0.5f)), info, color);
        }
        else
        {
            text.SetText(position, info, color);
        }

    }





#if UNITY_EDITOR

    protected override void OnBindField()
    {
        base.OnBindField();
        _noticePopup = Resources.Load<GameObject>("UI/NoticePopup");
        _popupCanvas = GameObject.Find("PopupCanvas");
        _worldCanvas = GameObject.Find("WorldCanvas");
        _changeText = Resources.Load<GameObject>("UI/ChangeText");
        _warningPopup = Resources.Load<GameObject>("UI/WarningPopup");
        _eventPopup = Resources.Load<GameObject>("UI/EventPopup");
    }

    protected override void OnButtonField()
    {
        base.OnButtonField();
        GameObject gob = Resources.Load<GameObject>("UI/" + "EmployeeManagement");
        Debug.Log(gob.name);

    }

#endif
}
