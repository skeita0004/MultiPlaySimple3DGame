using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public IInput input;
    public PlayerMotor motor;

    public float walkSpeed;
    public float sprintSpeed;

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
        if (input.sprint)
        {
            motor.Move(input.move, sprintSpeed);
        }
        else
        {
            motor.Move(input.move, walkSpeed);
        }
    }
}
