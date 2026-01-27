

public class MoveCommand: ICommand
{
    public float Direction { get; }

    public MoveCommand(float direction)
    {
        Direction = direction;
    }
}
