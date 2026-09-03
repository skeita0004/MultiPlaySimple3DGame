using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadState : IState
{
    private PlayerController player_;

    private CharacterController characterCtrl_;

    private float sceneChangeTimer_ = 2f;
    public void Enter(PlayerController _player)
    {
        player_ = _player;
        characterCtrl_ = player_.GetComponent<CharacterController>();
        characterCtrl_.enabled = false;
        player_.motor.DisableMove();
        player_.animator.Play(PlayerAnimation.DEAD, 0.1f);
        DeadChecker.isSomeoneDied = true;
        DeadChecker.deceasedName = player_.name;
    }

    public void Update()
    {
        if (player_.animator.GetNormalizedTime() > 1.0f)
        {
            sceneChangeTimer_ -= Time.deltaTime;
            if (sceneChangeTimer_ < 0)
            {
                SceneManager.LoadScene("Result");
            }   
        }
    }

    public void Exit()
    {

    }
}
