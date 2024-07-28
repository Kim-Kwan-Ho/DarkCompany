using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WarningPopup : UIPopup
{
    [SerializeField] private TextMeshProUGUI _noticeText;
    [SerializeField] private Button _closeButton;


    protected override void Awake()
    {
        base.Awake();
        _closeButton.onClick.AddListener(CloseWarning);
    }

    public void SetText(string info)
    {
        _noticeText.text = info;
    }

    private void CloseWarning()
    {
        UIManager.Instance.CloseWarningPopup();
        Destroy(this.gameObject);
    }
#if UNITY_EDITOR
    protected override void OnBindField()
    {
        base.OnBindField();
        _noticeText = FindGameObjectInChildren<TextMeshProUGUI>("NoticeText");
        _closeButton = FindGameObjectInChildren<Button>("CloseButton");
    }
#endif
}
