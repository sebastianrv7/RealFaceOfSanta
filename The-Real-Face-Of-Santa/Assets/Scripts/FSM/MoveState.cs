using UnityEngine;

public class MoveState: IState
{
    private PlayerController player;
    

    public string GetName() => "Move";  //  No olvides esto para debug

    public MoveState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        player.Animator.Play("Walk");
    }

    public void Exit()
    {        
        
    }

    public void Update() { }

    public void FixedUpdate()
    {
        player.Motor.Move(player.LastInputDirection);
        //Debug.Log("MoveState aplicando: " + player.LastInputDirection);
    }

    public void HandleCommand(ICommand command)
    {
        if (command is MoveCommand move)
        {
            player.LastInputDirection = move.Direction;

            if (move.Direction == 0f)  
            {                
                player.ChangeState(player.IdleState);
            }
        }

        if (command is JumpCommand)
        {            
            player.ChangeState(player.JumpState);
        }
    }
}
