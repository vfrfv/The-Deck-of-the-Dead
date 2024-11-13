using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shotEffect;
    [SerializeField] private WeaponStatus _weaponStatus;
    [SerializeField] private int _damage;
    [SerializeField] private float _delayBetweenShots;

    public float DelayBetweenShots => _delayBetweenShots;
    public WeaponStatus WeaponStatus => _weaponStatus;

    public int Shooting()
    {
        _shotEffect.Play();
        return _damage;
    }
}