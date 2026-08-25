using System.Xml;
using UnityEngine;

public class DeadState : IState
{
    private PlayerController player_;

    public void Enter(PlayerController _player)
    {
        player_ = _player;
        player_.animator.Play(PlayerAnimation.DEAD, 0.1f);
        player_.motor.DisableMove();
    }

    public void Update()
    {
    }

    public void Exit()
    {

    }
}
