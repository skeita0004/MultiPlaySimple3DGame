using UnityEngine;
using NUnit.Framework.Internal.Filters;

public class PlayerController : MonoBehaviour
{
    public IInput         input;
    public PlayerMotor    motor;
    public PlayerCamera   playerCamera;
    public PlayerAnimator animator;
    public PlayerStatus   status;
    public Weapon         weapon;

    public float walkSpeed;
    public float sprintSpeed;

    private IState currentState_;

    void Awake()
    {
    }

    void Start()
    {
        //if (!IsOwner)
        //{
        //    input = GetComponent<RemoteInput>();
        //}
        //else
        {
            input = GetComponent<LocalInput>();
        }

        motor    = GetComponent<PlayerMotor>();
        animator = GetComponent<PlayerAnimator>();
        status   = GetComponent<PlayerStatus>();
        weapon   = GetComponent<Weapon>();

        // 初期状態の設定
        currentState_ = new IdleState();
        currentState_.Enter(this);
    }

    void Update()
    {

        if ( playerCamera != null )
        {
            playerCamera.Look(input.look, transform.position);
        }

        currentState_.Update();
    }

    public void ChangeState(IState _newState)
    {
        currentState_.Exit();
        currentState_ = _newState;
        currentState_.Enter(this);
    }
}
