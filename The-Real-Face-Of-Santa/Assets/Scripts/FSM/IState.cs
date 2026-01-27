

public interface IState
{
    void Enter();
    void Exit();
    void Update();
    void FixedUpdate();
    void HandleCommand(ICommand command);
    string GetName();
}
