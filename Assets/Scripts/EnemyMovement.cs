using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    
    public void MoveEnemy(Vector2 target, float speed)
    {
        Vector2 direction = new Vector2(target.x - transform.position.x, target.y - transform.position.y).normalized;

        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);

    }

}
