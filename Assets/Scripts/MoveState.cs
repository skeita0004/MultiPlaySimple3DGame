using UnityEngine;
using UnityEngine.Windows;

public class MoveState : IState
{
    private PlayerController player_;

    public void Enter(PlayerController _player)
    {
        player_ = _player;
        player_.animator.Play(PlayerAnimation.WALK, 0.1f);
    }

    public void Update()
    {
        if (player_.input.move == Vector2.zero)
        {
            player_.ChangeState(new IdleState());
            return;
        }

        if ( player_.input.attack )
        {
            player_.ChangeState(new AttackState());
            return;
        }

        // 移動
        Move();
    }

    public void Exit()
    {

    }

    private void Move()
    {
        float moveSpeed = player_.walkSpeed;
        if (player_.input.sprint)
        {
            moveSpeed = player_.sprintSpeed;
            player_.animator.Play(PlayerAnimation.RUN, 0.1f);
        }
        else if (!player_.input.sprint)
        {
            player_.animator.Play(PlayerAnimation.WALK, 0.1f);
        }
        player_.motor.Move(player_.input.move,
                           moveSpeed,
                           player_.playerCamera.tpsCamera.transform.localRotation);
    }
}
