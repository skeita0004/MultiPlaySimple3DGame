using System.Xml;
using UnityEngine;

public class DeadState : IState
{
    private PlayerController player_;
    private CapsuleCollider playerCollider_;

    public void Enter(PlayerController _player)
    {
        player_ = _player;
        player_.animator.Play(PlayerAnimation.DEAD, 0.1f);
        player_.motor.DisableMove();
        playerCollider_ = player_.GetComponent<CapsuleCollider>();
        playerCollider_.enabled = false;
    }

    public void Update()
    {
    }

    public void Exit()
    {

    }
}
