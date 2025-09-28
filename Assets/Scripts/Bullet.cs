using NUnit.Framework;
using System.Xml.Schema;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private float speed;
    [SerializeField] private int hitDamage;
    private PooledObject pooledObject;
    
    private Rigidbody2D rb;
    private Transform target;
   

    private void Awake()
    {
        pooledObject = GetComponent<PooledObject>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void FixedUpdate()
    {
        if (target == null)
            return;

        Vector2 direction = (target.position - transform.position).normalized;

        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }
    //hacer la colision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageEnemy))
        {
            damageEnemy.Damage(hitDamage);
        }
        pooledObject.Release();
    }




}
