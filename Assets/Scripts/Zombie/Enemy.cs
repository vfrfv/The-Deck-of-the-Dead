using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    private Character _target;

    public Character Target => _target;

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    public void InitializeTarget(Character target)
    {
        _target = target;
    }
}
