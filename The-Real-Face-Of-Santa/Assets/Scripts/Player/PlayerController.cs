using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler inputHandler;
    [SerializeField] private Rigidbody2D rb;

    private StateMachine stateMachine;
    public StateMachine StateMachine => stateMachine;
    private MovementMotor motor;
    public MovementMotor Motor => motor;

    public float FacingDirection { get; private set; } = 1f;

    public Animator Animator { get; private set; }

    public SpriteRenderer Sprite { get; private set; }

    private float lastInputDirection;

    public float LastInputDirection
    {
        get => lastInputDirection;
        set => lastInputDirection = value;
    }
    public float VerticalVelocity => rb.linearVelocity.y;
    public bool IsGrounded => isGrounded;

    private bool isGrounded;

    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.8f, 0.1f);


    public IdleState IdleState { get; private set; }
    public MoveState MoveState { get; private set; }
    public JumpState JumpState { get; private set; }
    public FallState FallState { get; private set; }
    

    private void Awake()
    {
        stateMachine = new StateMachine();
        motor = new MovementMotor(rb);
        IdleState = new IdleState(this);
        MoveState = new MoveState(this);
        JumpState = new JumpState(this);
        FallState = new FallState(this);
        Animator = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();

        stateMachine.SetState(IdleState);
    }

    private void Start()
    {
        inputHandler.OnCommandGenerated += HandleCommand;
    }

    private void OnEnable()
    {
        inputHandler.OnCommandGenerated += HandleCommand;
    }

    private void OnDisable()
    {
        inputHandler.OnCommandGenerated -= HandleCommand;
    }

    private void Update()
    {
        stateMachine.CurrentState?.Update();
    }

    private void FixedUpdate()
    {
        UpdateGroundCheck();                    
        stateMachine.CurrentState?.FixedUpdate(); 
    }

    private void HandleCommand(ICommand command)
    {
        stateMachine.HandleCommand(command);
    }

    public void ChangeState(IState newState)
    {
        stateMachine.SetState(newState);
    }

    private void UpdateGroundCheck()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
        groundCheckPoint.position,
        groundCheckSize,
        0f,
        Vector2.down,
        groundCheckDistance,
        groundLayer
    );

        isGrounded = hit.collider != null;
    }

    public void UpdateFacing(float direction)
    {
        if (direction == 0f) return;

        FacingDirection = Mathf.Sign(direction);
        Sprite.flipX = FacingDirection < 0;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheckPoint == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(
            groundCheckPoint.position + Vector3.down * groundCheckDistance,
            groundCheckSize
        );
    }

}
