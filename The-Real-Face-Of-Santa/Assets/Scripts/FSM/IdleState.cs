using UnityEngine;

public class IdleState: IState
{
    private PlayerController player;

    public string GetName() => "Idle";

    public IdleState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        player.Motor.Stop();
        player.Animator.Play("Idle");
        //Debug.Log("Se entró en IdleState y la direccion es: " + player.LastInputDirection);
    }

    public void Exit() {
        //Debug.Log("[IdleState] Exit");
    }

    public void Update() { }

    public void FixedUpdate() { }

    public void HandleCommand(ICommand command)
    {         

        if (command is MoveCommand move)
        {
            if (move.Direction != 0f)
            {
                
                player.ChangeState(player.MoveState);
            }
        }

        if (command is JumpCommand)
        {
            
            player.ChangeState(player.JumpState);
        }
    }
}
