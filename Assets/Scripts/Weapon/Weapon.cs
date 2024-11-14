using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shotEffect;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private List<Transform> _bulletPoints;
    [SerializeField] private WeaponStatus _weaponStatus;

    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name;
    [SerializeField] private int _price;

    [SerializeField] private float _attackDistance;
    [SerializeField] private int _damage;
    [SerializeField] private float _delayBetweenShots;

    public float DelayBetweenShots => _delayBetweenShots;
    public WeaponStatus WeaponStatus => _weaponStatus;
    public float AttackDistance => _attackDistance;
    public Sprite Icon => _icon;
    public string Name => _name;
    public int Price => _price;

    public int Shooting()
    {
        _shotEffect.Play();

        if (_bulletPoints.Count > 1)
        {
            for (int i = 0; i < _bulletPoints.Count; i++)
            {
                Instantiate(_bullet, _bulletPoints[i].position, _bulletPoints[i].rotation);
            }
        }

        Instantiate(_bullet, _bulletPoints[0].position, _bulletPoints[0].rotation);

        return _damage;
    }
}