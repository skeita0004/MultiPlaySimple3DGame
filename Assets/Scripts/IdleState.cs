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
        if ( player_.input.move != Vector2.zero)
        {
            player_.ChangeState(new MoveState());
            return;
        }
    }

    public void Exit()
    {

    }

    private void ShouldMove()
    {

    }
}
