public class IdlingPistolState : MovementState
{
    public IdlingPistolState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        CharacterView.StartIdlingPistol();
    }

    public override void Exit()
    {
        base.Exit();

        CharacterView.StopIdlingPistol();
    }

    public override void Update()
    {
        base.Update();

        if (IsMoving())
            return;

        StateSwitcher.SwitchState<RunningDefaultState>();
    }
}
