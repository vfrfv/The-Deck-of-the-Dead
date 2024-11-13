using System.Collections;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private Transform _weaponPoint;
    [SerializeField] private float _radius;

    private Enemy _currentEnemy;

    public bool IsShooting { get; private set; } = false;
    public Weapon CurrentWeapon => _currentWeapon;

    private void Start()
    {
        Instantiate(_currentWeapon, _weaponPoint);
        StartCoroutine(SearchEnemy());
    }

    private void Update()
    {
        if (_currentEnemy != null)
        {
            transform.LookAt(_currentEnemy.transform);
        }
    }

    private IEnumerator Shooting()
    {
        IsShooting = true;

        var delay = new WaitForSeconds(_currentWeapon.DelayBetweenShots);

        StopCoroutine(SearchEnemy());

        while (_currentEnemy != null)
        {
            _currentEnemy.TakeDamage(_currentWeapon.Shooting());

            yield return delay;
        }
    }

    private IEnumerator SearchEnemy()
    {
        IsShooting = false;

        StopCoroutine(Shooting());

        while (_currentEnemy == null)
        {
            Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _radius);
            Rigidbody rigidbody;

            for (int i = 0; i < overlappedColliders.Length; i++)
            {
                rigidbody = overlappedColliders[i].attachedRigidbody;

                if (rigidbody)
                {
                    if (rigidbody.gameObject.TryGetComponent(out Enemy enemy))
                    {
                        _currentEnemy = enemy;
                        _currentEnemy.Diying += TargetKilled;

                        StartCoroutine(Shooting());
                        break;
                    }
                }
            }

            yield return null;
        }
    }

    private void TargetKilled()
    {
        _currentEnemy.Diying -= TargetKilled;
        _currentEnemy = null;

        StartCoroutine(SearchEnemy());
    }
}