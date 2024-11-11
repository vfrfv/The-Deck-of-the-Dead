using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : MovementState
{
    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = 5;
    }

    public override void Update()
    {
        base.Update();

        if (// ”слови€ дл€ перехода в јйдл—тате)
            StateSwitcher.SwitchState<IdlingState>();
    }
}
