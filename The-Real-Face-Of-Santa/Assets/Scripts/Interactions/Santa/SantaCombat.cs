using UnityEngine;
using System.Collections;
public class SantaCombat : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    [SerializeField] private BoxCollider2D santaCollider;
    [SerializeField] private BoxCollider2D weakPointCollider;

    [Header("Timings")]
    [SerializeField] private float waitTime = 0.5f;
    [SerializeField] private float prepareTime = 0.5f;

    [Header("Dash")]
    [SerializeField] private float dashSpeed = 10f;

    [SerializeField]
    private GameManager gameManager;

    private bool combatActive = false;

    private bool goingToB = true;

    [SerializeField]
    public bool combatStarted = false;

    public void StartCombat()
    {
        if (combatActive) return;

        combatActive = true;
        StartCoroutine(CombatLoop());
    }

    public IEnumerator CombatLoop()
    {
        while (combatActive)
        {
            // Espera
            yield return new WaitForSeconds(waitTime);

            // Preparación
            
            yield return new WaitForSeconds(prepareTime);

            // Dash
            Transform target = goingToB ? pointB : pointA;
            
            yield return StartCoroutine(DashTo(target));

            yield return new WaitForSeconds(2);
            Flip();
            // Cambia dirección
            goingToB = !goingToB;
        }
    }

    private IEnumerator DashTo(Transform target)
    {
        while (Vector2.Distance(transform.position, target.position) > 0.05f)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                target.position,
                dashSpeed * Time.deltaTime
            );
            yield return null;
        }
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.LoseGame();
        }
    }

    public void SantaWin()
    {
        combatActive = false; // detiene la coroutine

        // Desactiva colliders del boss
        foreach (Collider2D col in GetComponents<Collider2D>())
        {
            col.enabled = false;
        }

        // Desactiva colliders de los waypoints
        print("hola");
        DisableWaypointColliders(santaCollider);
        DisableWaypointColliders(weakPointCollider);


    }

    private void DisableWaypointColliders(BoxCollider2D point)
    {
        if (point == null) return;

        foreach (Collider2D col in point.GetComponents<Collider2D>())
        {
            col.enabled = false;
        }
    }

    
    public void StopCombatImmediate()
    {
        combatActive = false;
        StopAllCoroutines();
    }

}
