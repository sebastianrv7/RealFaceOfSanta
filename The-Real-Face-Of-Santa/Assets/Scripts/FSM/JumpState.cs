using UnityEngine;

public class JumpState: IState
{
    private PlayerController player;
    

    public string GetName() => "Jump";

    public JumpState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        player.Motor.Jump();
        player.Animator.Play("Jump");
    }

    public void Exit()
    {
        
    }

    public void Update() { }

    public void FixedUpdate()
    {
        
        if (player.LastInputDirection != 0f)
        {
            player.Motor.Move(player.LastInputDirection);
        }

        if (player.VerticalVelocity <= 0f)
        {
            player.ChangeState(player.FallState);
        }
    }

    public void HandleCommand(ICommand command)
    {
        if (command is MoveCommand move)
        {
            player.LastInputDirection = move.Direction;
        }
    }
}
