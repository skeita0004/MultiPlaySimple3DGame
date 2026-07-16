using UnityEngine;
using UnityEngine.Windows;

public class MoveState : IState
{
    private PlayerController player_;

    public void Enter(PlayerController _player)
    {
        player_ = _player;
    }
    public void Update()
    {
        float moveSpeed = player_.walkSpeed;
        if (player_.input.sprint)
        {
            moveSpeed = player_.sprintSpeed;
        }
        player_.motor.Move(player_.input.move, moveSpeed, player_.playerCamera.tpsCamera.transform.localRotation);
    }

    public void Exit()
    {

    }
}
