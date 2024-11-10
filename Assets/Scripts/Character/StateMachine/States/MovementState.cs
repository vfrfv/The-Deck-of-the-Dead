using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;

    private readonly Character _character;

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _character = character;
    }

    protected CharacterMovement Input => _character.Input; // PlayerInput
    protected CharacterController CharacterController => _character.Controller;

    protected Vector3 Velocity { get; private set; }

    public void Enter()
    {
        Debug.Log(GetType());
    }

    public void Exit() { }

    public void HandleInput()
    {
        Data.XInput = ReadHorizontalInput();
    }


    public void Update()
    {
        throw new System.NotImplementedException();
    }

    private float ReadHorizontalInput() => ; // тут нужно считывать ввод 
}