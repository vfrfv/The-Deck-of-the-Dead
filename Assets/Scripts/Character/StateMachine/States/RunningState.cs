using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

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
        _character.transform.Translate(0, 0, 3 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.A))
            StateSwitcher.SwitchState<IdlingState>();
    }
}
