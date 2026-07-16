using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public IInput input;
    public PlayerMotor motor;
    public PlayerCamera playerCamera;

    public float walkSpeed;
    public float sprintSpeed;

    private IState currentState_;

    void Awake()
    {
        input = GetComponent<LocalInput>();
        Debug.Log(input);

        motor = GetComponent<PlayerMotor>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        playerCamera.Look(input.look, transform.position);

        currentState_.Update();
    }
}
