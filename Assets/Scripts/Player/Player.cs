using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChanget;
    public event UnityAction Died;

    private void Start()
    {
        HealthChanget?.Invoke(_health);
    }
    public void ApplayDamage(int damage)
    {
        _health -= damage;
        HealthChanget?.Invoke(_health);

        if(_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
