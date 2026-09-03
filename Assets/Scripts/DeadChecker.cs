using UnityEngine;

public class DeadChecker : MonoBehaviour
{
    public static bool isSomeoneDied = false;
    public static string deceasedName = "None";
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSomeoneDied)
        {
            if (deceasedName == "Player01")
            {
                SetWinnerName.winner = "Player02";
            }
            else
            {
                SetWinnerName.winner = "Player01";
            }
        }
    }
}
