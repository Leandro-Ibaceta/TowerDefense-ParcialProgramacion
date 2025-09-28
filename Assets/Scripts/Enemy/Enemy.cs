using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


[RequireComponent(typeof(EnemyMovement))]
public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] protected int health;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected int damage;
    private Transform target;
    private EnemyMovement enemyMovement;
    private int index = 0;
    public int Health => health;

    public void Damage(int damage)
    {
       health -= damage;
    }
    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }
    private void Start()
    {
        target = GameManager.instance.waypoint[index];
    }

    private void Update()
    {
        if(!IsAlive())
        {
            GameManager.instance.EnemyKilled++;
            Destroy(this.gameObject); 
            return;
        }
        enemyMovement.MoveEnemy(target.position, moveSpeed);

        if (CheckForDistance() <= 0.5f)
        {
            index++;
            if (index == GameManager.instance.waypoint.Length)
            {
                Destroy(gameObject);
                return;
            }
            target = GameManager.instance.waypoint[index];
        }
    }

    private float CheckForDistance()
    {
        float distance = Vector2.Distance(target.position, transform.position);
        return distance;
    }

    private bool IsAlive()
    {
        return health > 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.Damage(damage);
        }
    }
}
