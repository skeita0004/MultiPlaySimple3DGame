using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController characterController_;
    
    private Vector3 velocity_;
    private Vector3 moveDir_;
    
    private bool canMove_;

    private Transform skin_;

    void Awake()
    {
        characterController_ = GetComponent<CharacterController>();
    }

    void Start()
    {
        skin_ = transform.Find("Model");
    }

    void FixedUpdate()
    {
        
    }

    public void Move(Vector2 _input, float _speed, Quaternion _cameraYaw)
    {
        // 正面, 右ベクトルを求める
        Vector3 forward = _cameraYaw * Vector3.forward;
        Vector3 right   = _cameraYaw * Vector3.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // 入力処理
        Vector3 moveDir = forward * _input.y + right * _input.x;
        
        if (moveDir.sqrMagnitude > 1f)
        {
            moveDir.Normalize();
        }

        // 移動
        velocity_ = new Vector3(moveDir.x, 0.0f, moveDir.z) * _speed;
        characterController_.Move(velocity_ * Time.deltaTime);
        skin_.rotation = _cameraYaw;

        Debug.Log(characterController_.transform.name);
        if ( moveDir.sqrMagnitude > 0.01f )
        {
            skin_.rotation = Quaternion.LookRotation(moveDir);
        }
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
