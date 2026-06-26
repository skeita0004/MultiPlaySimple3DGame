using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 6.0f;

    private CharacterController controller_;
    
    private Vector3 moveDirection_ = Vector3.zero;
    private Vector3 moveVelocity_ = Vector3.zero;

    private InputAction move_;
    private InputAction look_;


    void Start()
    {
        controller_ = GetComponent<CharacterController>();

        move_ = InputSystem.actions.FindAction("Move");
        look_ = InputSystem.actions.FindAction("Look");
    }

    void Update()
    {
        Vector2 moveValue = move_.ReadValue<Vector2>();

        moveDirection_ = new Vector3(moveValue.x, 0.0f, moveValue.y);
        moveDirection_ = transform.TransformDirection(moveDirection_);
        moveVelocity_ = moveDirection_ * speed;
        controller_.Move(moveVelocity_ * Time.deltaTime);

        Vector2 lookValue = look_.ReadValue<Vector2>();
        transform.RotateAround(transform.position, Vector3.up, lookValue.x);
        // TODO: Lookによる視点操作
    }
}
