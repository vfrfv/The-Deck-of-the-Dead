using System;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class Character : Health , IValue
{
    [SerializeField] private CharacterView _characterView;

    private CharacterShooting _characterShooting;
    private CharacterMovement _movement;
    private CharacterStateMachine _stateMachine;

    int IValue.MaxValue => MaxValue;
    int IValue.Value => Value;
    public CharacterMovement Movement => _movement;
    public CharacterView CharacterView => _characterView;
    public CharacterShooting CharacterShooting => _characterShooting;

    public event Action<int> Changed;

    private void Awake()
    {
        _characterShooting = GetComponent<CharacterShooting>();
        _characterView.Initialize();
        _movement = GetComponent<CharacterMovement>();
        _stateMachine = new CharacterStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    public override void TakeDamage(int damage)
    {
        Value -= damage;
        Changed?.Invoke(Value);

        if (Value <= 0)
        {
            Destroy(gameObject);
        }
    }
}