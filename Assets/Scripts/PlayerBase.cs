using System;
using UnityEngine;

public class PlayerBase : MonoBehaviour, IDamageable
{
     
    public event Action OnBaseHit;

    
    public void Damage(int damage)
    {
        int health = GameManager.instance.PlayerHealth;
        if( health <= 0)
        {
            GameManager.instance.YouLose();
            return;
        }
        GameManager.instance.PlayerHealth -= damage;
        OnBaseHit?.Invoke();
        Debug.Log("Player received damage");        
    }
}
