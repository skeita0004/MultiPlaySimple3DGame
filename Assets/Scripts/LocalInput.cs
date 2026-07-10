using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalInput : MonoBehaviour, IInput
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

    void Awake()
    {
        playerInput_ = GetComponent<PlayerInput>();
    }
    void Start()
    {
    }

    void Update()
    {
        move = playerInput_.actions["Move"].ReadValue<Vector2>();
        look = playerInput_.actions["Look"].ReadValue<Vector2>();

        attack = playerInput_.actions["Attack"].IsPressed();
        sprint = playerInput_.actions["Sprint"].IsPressed();
        guard  = playerInput_.actions["Guard"].IsPressed();
        ok     = playerInput_.actions["Interact"].IsPressed();
    }
}
