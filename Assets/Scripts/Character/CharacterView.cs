using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
    private Animator _animator;

    public void Initialize() => _animator = GetComponent<Animator>();

    public void StartState(string state) => _animator.SetBool(state, true);
    public void StopState(string state) => _animator.SetBool(state, false);
}
