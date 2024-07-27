using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoticePopup : UIPopup
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private TextMeshProUGUI _noticeText;


    protected override void Initialize()
    {
        base.Initialize();
        _closeButton.onClick.AddListener(ClosePopup);
    }

    public void SetText(string text)
    {
        _noticeText.text = text;
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