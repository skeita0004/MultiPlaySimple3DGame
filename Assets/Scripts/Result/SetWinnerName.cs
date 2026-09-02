using TMPro;
using Unity.Services.Matchmaker.Models;
using UnityEngine;

public class SetWinnerName : MonoBehaviour
{
    public static string winner = "None";
    private TMP_Text winner_;
    void Start()
    {
        winner_ = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        winner_.text = winner;
    }
}
