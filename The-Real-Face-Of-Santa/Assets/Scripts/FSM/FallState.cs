using UnityEngine;

public class FallState: IState
{
    private PlayerController player;
    

    public string GetName() => "Fall";

    public FallState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        player.Animator.Play("Fall");
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


        if (player.IsGrounded)
        {
            if (player.LastInputDirection != 0f)
            {
                player.ChangeState(player.MoveState);
            }
            else
            {
                player.ChangeState(player.IdleState);
            }
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
