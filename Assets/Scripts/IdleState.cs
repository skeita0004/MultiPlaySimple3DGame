using Unity.VisualScripting;
using UnityEngine;

public class IdleState : IState
{
    private PlayerController player_;
    private bool isAttackEntered_;


    public void Enter(PlayerController _player)
    {
        player_ = _player;
        player_.animator.Play(PlayerAnimation.IDLE, 0.1f);
        isAttackEntered_ = false;
    }

    public void Update()
    {
        // 移動時
        if ( player_.input.move != Vector2.zero)
        {
            player_.ChangeState(new MoveState());
            return;
        }

        if ( !isAttackEntered_ )
        {
            if ( player_.input.attack )
            {
                player_.ChangeState(new AttackState());
                isAttackEntered_ = true;
                return;
            }
            else if ( !player_.input.attack )
            {
                isAttackEntered_ = false;
            }
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
