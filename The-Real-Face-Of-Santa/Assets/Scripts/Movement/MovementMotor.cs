using UnityEngine;

public class MovementMotor
{
    private Rigidbody2D rb;

    private float moveSpeed = 7f;
    private float jumpForce = 15f;

    public MovementMotor(Rigidbody2D rb)
    {
        this.rb = rb;
    }

    // Movimiento horizontal (suelo)
    public void Move(float direction)
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed,rb.linearVelocity.y);
    }

    // Detener movimiento horizontal
    public void Stop()
    {
        rb.linearVelocity = new Vector2(0f,rb.linearVelocity.y);
    }

    // Salto
    public void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x,jumpForce);
    }
}
