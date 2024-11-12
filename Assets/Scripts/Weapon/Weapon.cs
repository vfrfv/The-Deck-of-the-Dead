using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponStatus _weaponStatus;
    [SerializeField] private int _damage;
    [SerializeField] private float _delayBetweenShots;

    public int Damage => _damage;
    public float DelayBetweenShots => _delayBetweenShots;
    public WeaponStatus WeaponStatus => _weaponStatus;
}