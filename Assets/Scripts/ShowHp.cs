using TMPro;
using UnityEngine;

public class ShowHp : MonoBehaviour
{
    public TMP_Text text;
    private PlayerStatus playerStatus_;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        playerStatus_ = GetComponentInParent<PlayerStatus>();
    }

    void Update()
    {
        text.text = $"HP : {playerStatus_.currentHP}";
    }
}
