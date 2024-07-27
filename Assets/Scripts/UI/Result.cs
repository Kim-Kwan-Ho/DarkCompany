using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : BaseBehaviour
{
    [SerializeField] private Image _fadeImage;

    [Header("Resources")]
    [SerializeField] private GameObject _successUI;
    [SerializeField] private GameObject _failureUI;

    [Header("Fade Property")]
    [SerializeField] private float _fadeTime;

    private void OnEnable()
    {
        GameSceneManager.Instance.EventGameScene.OnDayEnd += Event_OnDayEnd;
        GameSceneManager.Instance.EventGameScene.OnRequestNewDay += Event_RequestNewDay;
    }

    private void OnDisable()
    {
        GameSceneManager.Instance.EventGameScene.OnDayEnd -= Event_OnDayEnd;
        GameSceneManager.Instance.EventGameScene.OnRequestNewDay -= Event_RequestNewDay;
    }

    private void Event_OnDayEnd()
    {
        StartCoroutine(FadeOut());
    }

    private void Event_RequestNewDay()
    {
        StartCoroutine(FadeIn());
    }
    private void ShowResult()
    {
        if (GameSceneManager.Instance.CurrentMoney >= GameSceneManager.Instance.Charge)
        {
            ResultSuccess success = Instantiate(_successUI, transform).GetComponent<ResultSuccess>();
            success.SetResult(GameSceneManager.Instance.Day, GameSceneManager.Instance.TodayIncome, GameSceneManager.Instance.Charge);
        }
        else
        {
            ResultFailure failure = Instantiate(_failureUI, transform).GetComponent<ResultFailure>();
            failure.SetResult(GameSceneManager.Instance.Day, GameSceneManager.Instance.CurrentMoney, GameSceneManager.Instance.Charge);
        }
    }
    


    private IEnumerator FadeOut()
    {
        float time = 0;
        Color curColor = _fadeImage.color;
        Color targetColor = new Color(0, 0, 0, 1);


        while (time < _fadeTime)
        {
            _fadeImage.color = Color.Lerp(curColor, targetColor, time / _fadeTime);
            time += Time.deltaTime;
            yield return null;
        }
        _fadeImage.color = targetColor;
        ShowResult();
        yield break;
    }

    private IEnumerator FadeIn()
    {
        float time = 0;
        Color curColor = _fadeImage.color;
        Color targetColor = new Color(0, 0, 0, 0);

        while (time < _fadeTime)
        {
            _fadeImage.color = Color.Lerp(curColor, targetColor, time / _fadeTime);
            time += Time.deltaTime;
            yield return null;
        }
        _fadeImage.color = targetColor;
        GameSceneManager.Instance.EventGameScene.CallNewDayStart();
        yield break;
    }

#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        _fadeImage = FindGameObjectInChildren<Image>("FadeImage");
        _successUI = Resources.Load<GameObject>("UI/SuccessResult");
        _failureUI = Resources.Load<GameObject>("UI/FailureResult");

    }

#endif

}



