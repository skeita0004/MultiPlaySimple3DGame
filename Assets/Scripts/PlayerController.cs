using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public IInput input;
    public PlayerMotor motor;
    public PlayerCamera playerCamera;

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
        float moveSpeed = walkSpeed;
        if (input.sprint)
        {
            walkSpeed = sprintSpeed;
        }
        motor.Move(input.move, moveSpeed, playerCamera.tpsCamera.transform.localRotation);

        playerCamera.Look(input.look, transform.position);
    }
}
