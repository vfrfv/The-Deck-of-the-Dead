using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shotEffect;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _bulletPoint;
    [SerializeField] private WeaponStatus _weaponStatus;
    [SerializeField] private int _damage;
    [SerializeField] private float _delayBetweenShots;

    public float DelayBetweenShots => _delayBetweenShots;
    public WeaponStatus WeaponStatus => _weaponStatus;

    public int Shooting()
    {
        Instantiate(_bullet, _bulletPoint.position, _bulletPoint.rotation);
        _shotEffect.Play();

        return _damage;
    }
}