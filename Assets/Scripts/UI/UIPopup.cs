using UnityEngine;

public class UIPopup : BaseBehaviour
{
    protected override void Awake()
    {
        base.Awake();
        GameSceneManager.Instance.EventGameScene.OnDayEnd += ClosePopup;
    }

    private void OnDestroy()
    {
        GameSceneManager.Instance.EventGameScene.OnDayEnd -= ClosePopup;
    }

    public void ClosePopup()
    {
        Destroy(this.gameObject);
    }



}
