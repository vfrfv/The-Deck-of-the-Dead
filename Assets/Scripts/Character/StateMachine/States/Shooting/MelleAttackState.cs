public class MelleAttackState : MovementState
{
    public MelleAttackState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        CharacterView.StartMelleAttack();
    }

    public override void Exit()
    {
        base.Exit();

        CharacterView.StopMelleAttack();
    }
}