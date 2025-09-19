using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


[RequireComponent(typeof(EnemyMovement))]
public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] protected int health;
    [SerializeField] protected float moveSpeed;
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
}
