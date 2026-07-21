using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public IInput input;
    public PlayerMotor motor;
    public PlayerCamera playerCamera;
    public PlayerAnimator animator;

    public float walkSpeed;
    public float sprintSpeed;

    private IState currentState_;

    void Awake()
    {
        input = GetComponent<LocalInput>();
        motor = GetComponent<PlayerMotor>();
        animator = GetComponent<PlayerAnimator>();

        currentState_ = new IdleState();
        currentState_.Enter(this);
    }

    void Start()
    {
        
    }

    void Update()
    {
        playerCamera.Look(input.look, transform.position);
        
        currentState_.Update();
    }

    public void ChangeState(IState _newState)
    {
        currentState_.Exit();

        currentState_ = _newState;

        currentState_.Enter(this);
    }
}
