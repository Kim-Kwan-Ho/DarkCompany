using UnityEngine;

public class EmployeeEmoji : MonoBehaviour
{

    [SerializeField] private GameObject[] _emojis;


    public void CreateEmoji(EEmojiType type)
    {
        Instantiate(_emojis[(int)type], transform.position, Quaternion.identity);
    }
}


public enum EEmojiType
{
    RequestMoney,
    Stressed,
    Death,
    Happy
}