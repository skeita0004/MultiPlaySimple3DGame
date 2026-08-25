using UnityEngine;

public class IdleState : IState
{
    private PlayerController player_;

    public void Enter(PlayerController _player)
    {
        player_ = _player;
        player_.animator.Play(PlayerAnimation.IDLE, 0.1f);
    }

    public void Update()
    {
        // 移動時
        if ( player_.input.move != Vector2.zero)
        {
            player_.ChangeState(new MoveState());
            return;
        }

        if (player_.input.attack)
        {
            player_.ChangeState(new AttackState());
            return;
        }

        if (player_.input.guard)
        {
            player_.ChangeState(new GuardState());
            return;
        }

        if (player_.status.currentHP <= 0)
        {
            player_.ChangeState(new DeadState());
            return;
        }
    }

    public void Exit()
    {

    }
}
