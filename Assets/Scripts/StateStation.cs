using System.Xml;
using UnityEngine;

public class StateStation : IState
{
    private PlayerController player_;
    private bool isAttackEntered_;

    public void Enter(PlayerController _player)
    {
        player_ = _player;
    }

    public void Update()
    {
        if ( player_.input.attack )
        {
            //isAttackEntered_ = true;
            player_.ChangeState(new AttackState());
            return;
        }

        if ( player_.status.currentHP < 0 )
        {
            player_.ChangeState(new DeadState());
            return;
        }
    }

    public void Exit()
    {

    }
}
