using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float turretRange;
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private GameObject bulletPrebab;
    

    [SerializeField] private float fireRate;
    private float lastTimeSinceShoot = 0;
    

    private Transform target;
    //detect an Enemy
    private void Update()
    {
        
        if(target == null)
        {
            FindTarget();
            return;
        }
        
        

        if(!IsEnemyClose())
        {
            target = null;
        }else
        {
            lastTimeSinceShoot += Time.deltaTime;
            if(lastTimeSinceShoot > fireRate)
            {
                Shoot();
                lastTimeSinceShoot = 0;
            }
        }
            
    }

    private void FindTarget()
    {
        RaycastHit2D[] circleDetection = Physics2D.CircleCastAll(transform.position, turretRange, transform.position,0f,enemyLayerMask);

        if (circleDetection.Length > 0)
        {
            target = circleDetection[0].transform;
            
        }
    }
       
    private bool IsEnemyClose()
    {
        bool distance = Vector2.Distance(target.position, transform.position) <= turretRange;
        return distance;
    }

    private void Shoot()
    {
        GameObject projectile = ObjectPool.instance.GetPooledObject().gameObject;
        if (projectile == null)
            return;

        projectile.SetActive(true);
        projectile.transform.SetPositionAndRotation(FirePoint.position,Quaternion.identity);
        Bullet bullet = projectile.GetComponent<Bullet>();
        bullet.SetTarget(target);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, turretRange);   
    }
}
