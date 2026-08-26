using UnityEngine;

public class GuardState : IState
{
    private PlayerController player_;
    private bool isDifended_;

    public void Enter(PlayerController _player)
    {
        player_ = _player;
        if ( player_.status.guardLimit <= 0 )
        {
            return;
        }

        player_.animator.Play(PlayerAnimation.GUARD_IDLE, 0.1f);
        isDifended_ = false;
        player_.status.isGuard = true;
    }

    public void Update()
    {
        if ( player_.input.move != Vector2.zero && !(isDifended_) ) // 攻撃を受けた場合
        {
            player_.animator.Play(PlayerAnimation.GUARD_REACTION, 0.1f);
            player_.status.guardLimit -= 1;
            isDifended_ = true;
        }

        if (player_.animator.GetNormalizedTime() >= 1.0f && isDifended_)
        {
            isDifended_ = false;
            player_.animator.Play(PlayerAnimation.GUARD_IDLE, 0.1f);
        }

        if (player_.input.attack)
        {
            player_.ChangeState(new AttackState());
            return;
        }

        if ( !player_.input.guard )
        {
            player_.ChangeState(new IdleState());
            return;
        }
    }

    public void Exit()
    {
        player_.status.isGuard = false;
    }
}
