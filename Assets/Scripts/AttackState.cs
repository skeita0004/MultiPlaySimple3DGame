using UnityEngine;
using UnityEngine.Windows;

public class AttackState : IState
{
    private PlayerController player_;

    public void Enter(PlayerController _player)
    {
        Debug.Log("AttackStateへ遷移");
        player_ = _player;

        player_.weapon.Attack();
        player_.animator.Play(PlayerAnimation.ATTACK1, 0.05f);
    }

    public void Update()
    {

        if (player_.animator.GetNormalizedTime() > 1.0f)
        {
            if ( player_.input.move == Vector2.zero )
            {
                player_.ChangeState(new IdleState());
                return;
            }
            else // ( player_.input.move != Vector2.zero )
            {
                player_.ChangeState(new MoveState());
                return;
            }
        }

    }

    public void Exit()
    {
        player_.weapon.CancelAttack();
    }
}
