using UnityEngine;

public class GuardState : IState
{
    private PlayerController player_;

    private bool isDifended_;

    public void Enter(PlayerController _player)
    {
        player_ = _player;
        //if (player_.status.guardLimit > 3)
        //{
        //    return;
        //}

        player_.animator.Play(PlayerAnimation.GUARD_IDLE, 0.1f);
        isDifended_ = false;

    }

    public void Update()
    {
        //if ( player_.input.move != Vector2.zero && !(isDifended_)) // 攻撃を受けた場合
        //{
        //    player_.animator.Play(PlayerAnimation.GUARD_REACTION, 0.1f);
        //    player_.status.guardNum -= 1;
        //    isDifended_ = true;
        //}

        //if (player_.animator.currentAnimation == PlayerAnimation.GUARD_REACTION &&
        //    player_.animator.GetNormalizedTime() >= 1.0f && 
        //    isDifended_) // 現在のアニメーションが、GUARD_REACTIONかつ、NormalizedTimeが、1.0fより大きいとき
        //{
        //    isDifended_ = false;
        //    player_.animator.Play(PlayerAnimation.GUARD_IDLE, 0.1f);
        //}


        if ( !player_.input.guard )
        {
            player_.ChangeState(new IdleState());
            return;
        }
    }

    public void Exit()
    {

    }
}
