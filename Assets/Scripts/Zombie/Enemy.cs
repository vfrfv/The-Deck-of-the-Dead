using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    private Character _target;

    public event Action Diying;

    public Character Target => _target;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Diying?.Invoke();
            Destroy(gameObject);
        }
    }

    public void InitializeTarget(Character target)
    {
        _target = target;
    }
}
