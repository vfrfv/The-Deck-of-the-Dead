using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterView _characterView;

    private CharacterMovement _movement;
    private CharacterStateMachine _stateMachine;

    public CharacterMovement Movement => _movement;
    public CharacterView CharacterView => _characterView;

    private void Awake()
    {
        _characterView.Initialize();
        _movement = GetComponent<CharacterMovement>();
        _stateMachine = new CharacterStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.Update();
    }
}