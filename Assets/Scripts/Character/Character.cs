using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    private CharacterMovement _movement; //тут по уроку должно быть поле PlayerInput которое является New Input System
    private CharacterStateMachine _stateMachine;
    //private CharacterController _characterController;

    public CharacterMovement Movement => _movement;
    //public CharacterController Controller => _characterController;

    private void Awake()
    {
        //_characterController = GetComponent<CharacterController>();
        _movement = GetComponent<CharacterMovement>();
        _stateMachine = new CharacterStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.HandleInput();

        _stateMachine.Update();
    }
}