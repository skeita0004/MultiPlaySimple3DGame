using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string changeScene;

    public Fading fading;

    void Start()
    {
        
    }

    void Update()
    {
        if ( Keyboard.current.enterKey.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame )
        {
            SceneManager.LoadScene(changeScene);
            fading.CallCoroutine();
        }
    }
}
