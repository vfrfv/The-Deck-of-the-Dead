using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;

    /*private*/ protected readonly Character _character;

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _character = character;
    }

    //protected CharacterMovement Input => _character.Input; // PlayerInput
    //protected CharacterController CharacterController => _character.Controller;

    protected Vector3 Velocity { get; private set; }

    public virtual void Enter()
    {
        Debug.Log(GetType());
    }

    public virtual void Exit() { }

    public virtual void HandleInput()
    {
        //Data.XInput = ReadHorizontalInput();
        //Data.XVelocity = Data.XInput * Data.Speed;
    }

    public virtual void Update()
    {
        //Vector3 velocity = GetConvertedVelocity();
        //CharacterController.Move(velocity * Time.deltaTime);
        //_character.transform.rotation = GetRotationFrom(velocity);  
    }

    //private Quaternion GetRotationFrom(Vector3 velocity)
    //{
    //    if(velocity.x > 0)
    //        return new Quaternion(0,0, 0, 0);

    //    if(velocity.x < 0)
    //        return Quaternion.Euler(0,180,0);

    //    return _character.transform.rotation;
    //}

    //private Vector3 GetConvertedVelocity() => new Vector3(Data.XVelocity, Data.YVelocity, 0);


    //private float ReadHorizontalInput() => ; // тут нужно считывать ввод 
}