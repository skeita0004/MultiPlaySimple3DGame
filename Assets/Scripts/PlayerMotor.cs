using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController characterController_;
    
    private Vector3 velocity_;
    private Vector3 moveDir_;
    
    private bool canMove_;


    void Awake()
    {
        characterController_ = GetComponent<CharacterController>();
    }

    void Start()
    {
    }

    void FixedUpdate()
    {
        
    }

    public void Move(Vector2 _input, float _speed)
    {
        velocity_ = new Vector3(_input.x, 0.0f, _input.y) * _speed;
        characterController_.Move(velocity_ * Time.deltaTime);
    }

    public void Stop()
    {

    }

    public void SetVelocity(Vector3 _velocity)
    {
        velocity_ = _velocity;
    }

    public Vector3 GetVelocity()
    {
        return velocity_;
    }

    public void EnableMove()
    {
        canMove_ = true;
    }

    public void DisableMove()
    {
        canMove_ = false;
    }

    public bool CanMove()
    {
        return canMove_;
    }
}
