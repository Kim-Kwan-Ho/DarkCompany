using UnityEngine;

public class Emoji : MonoBehaviour
{
    [SerializeField] private EEmojiType _type;
    [SerializeField] private float _lifeTime;

    private void Update()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}
