using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
    private const string IsIdlingMelle = "IsIdlingMelle";
    private const string IsIdlingPistol = "IsIdlingPistol";
    private const string IsIdling2Hands = "IsIdling2Hands";

    private const string IsRunningDefault = "IsRunningDefault";
    private const string IsRunningPistol = "IsRunningPistol";
    private const string IsRunning2Hands = "IsRunning2Hands";

    private const string IsMelleAttack = "IsMelleAttack";
    private const string IsShootingPistol = "IsShootingPistol";
    private const string IsShooting2Hands = "IsShooting2Hands";

    private Animator _animator;

    public void Initialize() => _animator = GetComponent<Animator>();

    public void StartIdlingMelle() => _animator.SetBool(IsIdlingMelle, true);
    public void StopIdlingMelle() => _animator.SetBool(IsIdlingMelle, false);

    public void StartIdlingPistol() => _animator.SetBool(IsIdlingPistol, true);
    public void StopIdlingPistol() => _animator.SetBool(IsIdlingPistol, false);

    public void StartIdling2Hands() => _animator.SetBool(IsIdling2Hands, true);
    public void StopIdling2Hands() => _animator.SetBool(IsIdling2Hands, false);

    public void StartRunningDefault() => _animator.SetBool(IsRunningDefault, true);
    public void StopRunningDefault() => _animator.SetBool(IsRunningDefault, false);

    public void StartRunningPistol() => _animator.SetBool(IsRunningPistol, true);
    public void StopRunningPistol() => _animator.SetBool(IsRunningPistol, false);

    public void StartRunning2Hands() => _animator.SetBool(IsRunning2Hands, true);
    public void StopRunning2Hands() => _animator.SetBool(IsRunning2Hands, false);

    public void StartMelleAttack() => _animator.SetBool(IsMelleAttack, true);
    public void StopMelleAttack() => _animator.SetBool(IsMelleAttack, false);

    public void StartShootinPistol() => _animator.SetBool(IsShootingPistol, true);
    public void StopShootingPistol() => _animator.SetBool(IsShootingPistol, false);

    public void StartShootin2Hands() => _animator.SetBool(IsShooting2Hands, true);
    public void StopShooting2Hands() => _animator.SetBool(IsShooting2Hands, false);
}
