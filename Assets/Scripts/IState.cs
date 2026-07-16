public interface IState
{
    void Enter(PlayerController _player);
    void Update();
    void Exit();
}
