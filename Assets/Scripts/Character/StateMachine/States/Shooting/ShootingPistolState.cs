public class ShootingPistolState : MovementState
{
    public ShootingPistolState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        CharacterView.StartShootinPistol();
    }

    public override void Exit()
    {
        base.Exit();

        CharacterView.StopShootingPistol();
    }
}
