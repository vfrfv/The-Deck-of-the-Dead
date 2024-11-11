public class RunningPistolState : MovementState
{
    public RunningPistolState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        CharacterView.StartRunningPistol();
        Data.Speed = 5;
    }

    public override void Exit()
    {
        base.Exit();

        CharacterView.StopRunningPistol();
    }

    public override void Update()
    {
        base.Update();

        if (IsMoving())
            StateSwitcher.SwitchState<IdlingMelleState>();
    }
}
