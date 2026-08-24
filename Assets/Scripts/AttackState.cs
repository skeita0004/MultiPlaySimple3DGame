using UnityEngine;
using UnityEngine.Windows;

public class AttackState : IState
{
    private PlayerController player_;

    private static float attackTimer_ = 3f;

    private static int comboNum_ = 0;

    public void Enter(PlayerController _player)
    { 
        player_ = _player;
        //player_.animator.Play(PlayerAnimation.WALK, 0.1f);

        comboNum_ += 1;
    }

    public void Update()
    {
        Attack();
        player_.weapon.Attack();
        attackTimer_ -= Time.deltaTime;

        if (attackTimer_ < 0)
        {
            comboNum_ = 0;
            attackTimer_ = 1.5f;

            if ( player_.input.move == Vector2.zero )
            {
                player_.ChangeState(new IdleState());
                return;
            }
        }

        if (player_.input.attack)
        {
            player_.ChangeState(new AttackState());
            return;
        }

        if ( player_.input.move != Vector2.zero )
        {
            player_.ChangeState(new MoveState());
            return;
        }
    }

    public void Exit()
    {
        player_.weapon.CancelAttack();
    }

    private void Attack()
    {
        switch ( comboNum_ % 4 )
        {
            case 1:
                player_.animator.Play(PlayerAnimation.ATTACK1, 0.05f);
                break;
            case 2:
                player_.animator.Play(PlayerAnimation.ATTACK1, 0.05f);
                break;
            case 3:
                player_.animator.Play(PlayerAnimation.ATTACK1, 0.05f);
                break;
        }
    }
}
