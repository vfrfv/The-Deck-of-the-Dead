public class Running2HandsState : MovementState
{
    public Running2HandsState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        CharacterView.StartRunning2Hands();
        Data.Speed = 5;
    }

    public override void Exit()
    {
        base.Exit();

        CharacterView.StopRunning2Hands();
    }

    public override void Update()
    {
        base.Update();

        if (IsMoving())
            StateSwitcher.SwitchState<IdlingMelleState>();
    }
}
