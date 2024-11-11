using System.Collections.Generic;
using System.Linq;

public class CharacterStateMachine: IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public CharacterStateMachine(Character character)
    {
        StateMachineData data = new StateMachineData();

        _states = new List<IState>()
        {
            new IdlingMelleState(this, data, character),
            new IdlingPistolState(this, data, character),
            new Idling2Hands(this, data, character),
            new RunningDefaultState(this, data, character),
            new RunningPistolState(this, data, character),
            new Running2HandsState(this, data, character),
            new MelleAttackState(this, data, character),
            new ShootingPistolState(this, data, character),
            new Shooting2HandsState(this, data, character)
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<State>() where State : IState
    {
        IState state = _states.FirstOrDefault(state => state is State);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update() => _currentState.Update();
}