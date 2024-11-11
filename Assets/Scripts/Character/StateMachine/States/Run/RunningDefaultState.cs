public class RunningDefaultState : MovementState
{
    public RunningDefaultState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        CharacterView.StartRunningDefault();
        Data.Speed = 5;
    }

    public override void Exit()
    {
        base.Exit();

        CharacterView.StopRunningDefault();
    }

    public override void Update()
    {
        base.Update();

        if (IsMoving())
            StateSwitcher.SwitchState<IdlingMelleState>();
    }
}
