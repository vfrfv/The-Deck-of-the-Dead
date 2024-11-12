using UnityEngine;

public class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;

    private readonly Character _character;

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _character = character;
    }

    protected CharacterView CharacterView => _character.CharacterView;
    protected Character Character => _character;

    public virtual void Enter()
    {
        Debug.Log(GetType());
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {
    }

    protected bool IsMoving() => Character.Movement.NavMeshAgent.speed == 0;
    protected bool IsAttacking() => Character.CharacterShooting.IsShooting;
}