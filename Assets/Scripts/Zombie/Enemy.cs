using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class Enemy : Health, IValue
{
    [SerializeField] private ZombieView _zombieView;

    private Character _character;
    private ZombieAttack _zombieAttack;
    private EnemyMovement _movement;
    private ZombieStateMachine _zombieStateMachine;

    public event Action Diying;
    public event Action<int> Changed;

    int IValue.MaxValue => MaxValue;
    int IValue.Value => Value;
    public EnemyMovement Movement => _movement;
    public Character Target => _character;
    public ZombieView ZombieView => _zombieView;
    public ZombieAttack ZombieAttack => _zombieAttack;

    private void Awake()
    {
        _zombieAttack = GetComponent<ZombieAttack>();
        _zombieView.Initialize();
        _movement = GetComponent<EnemyMovement>();
        _zombieStateMachine = new ZombieStateMachine(this);
    }

    private void Update()
    {
        _zombieStateMachine.Update();
    }

    public override void TakeDamage(int damage)
    {
        Value -= damage;
        Changed?.Invoke(Value);

        if (Value <= 0)
        {
            Diying?.Invoke();
            Destroy(gameObject);
        }
    }

    public void InitializeTarget(Character target)
    {
        _character = target;
    }
}
