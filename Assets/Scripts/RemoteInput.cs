using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RemoteInput : MonoBehaviour, IInput
{
    public Vector2 move
    {
        get;
        set;
    }
    public Vector2 look
    {
        get;
        set;
    }

    public bool attack
    {
        get;
        set;
    }
    public bool sprint
    {
        get;
        set;
    }
    public bool guard
    {
        get;
        set;
    }
    public bool ok
    {
        get;
        set;
    }

    private PlayerInput playerInput_;

    void ApplyRecivedInput()
    {
        
    }
    void Update()
    {
        //ApplyRecivedInput();

        move = Vector2.zero;
        look = Vector2.zero;

        attack = false;
        sprint = false;
        guard = false;
        ok = false;
    }

}
