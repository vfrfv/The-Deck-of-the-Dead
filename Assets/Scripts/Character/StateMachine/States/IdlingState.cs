using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlingState : MovementState
{
    public IdlingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Update()
    {
        base.Update();

        if (// Условия перехода в ходьбу)
            StateSwitcher.SwitchState<RunningState>();
    }
}
