using System.Collections;
using TMPro;
using UnityEngine;

public class ChangeText : BaseBehaviour
{
    [SerializeField] private TextMeshProUGUI _changeText;

    [Header("Spawn Settings")]
    [SerializeField]
    private Vector2 _offSet;
    [SerializeField]
    private float _lifeTime = 1.0f;
    [SerializeField]
    private float _moveSpeed = 0.5f;




    private IEnumerator CoVisualize()
    {
        Color curColor = _changeText.color;
        Color targetColor = new Color(0, 0, 0, 0);
        float curTime = 0;
        while (curTime < _lifeTime)
        {
            transform.position += Vector3.up * _moveSpeed * Time.deltaTime;
            _changeText.color = Color.Lerp(curColor, targetColor, curTime / _lifeTime);
            curTime += Time.deltaTime;
            yield return null;
        }

        _changeText.color = targetColor;
        Destroy(this.gameObject);
    }
    public void SetText(Vector2 position, string text, Color color)
    {
        transform.position = position + _offSet;
        _changeText.color = color;
        _changeText.text = text;
        StartCoroutine(CoVisualize());
    }

#if UNITY_EDITOR

    protected override void OnBindField()
    {
        base.OnBindField();
        _changeText = GetComponent<TextMeshProUGUI>();
    }
#endif



}
