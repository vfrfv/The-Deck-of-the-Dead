public class IdlingMelleState : MovementState
{
    public IdlingMelleState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        CharacterView.StartIdlingMelle();
    }

    public override void Exit()
    {
        base.Exit();

        CharacterView.StopIdlingMelle();
    }

    public override void Update()
    {
        base.Update();

        if (IsMoving())
            return;

        StateSwitcher.SwitchState<RunningDefaultState>();
    }
}
