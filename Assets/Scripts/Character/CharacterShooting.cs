using System.Collections;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private float _radius;

    private Enemy _currentEnemy;
    private Coroutine _searchEnemy;
    private Coroutine _shooting;

    public bool IsShooting { get; private set; } = false;
    public Weapon CurrentWeapon => _currentWeapon;

    private void Start()
    {
        _searchEnemy = StartCoroutine(SearchEnemy());
    }

    private IEnumerator Shooting()
    {
        IsShooting = true;

        var delay = new WaitForSeconds(_currentWeapon.DelayBetweenShots);

        if (_searchEnemy != null)
        {
            StopCoroutine(SearchEnemy());
        }

        while (_currentEnemy != null)
        {
            _currentEnemy.TakeDamage(_currentWeapon.Damage);

            yield return delay;
        }
    }

    private IEnumerator SearchEnemy()
    {
        IsShooting = false;

        if (_shooting != null)
        {
            StopCoroutine(Shooting());
        }

        while (_currentEnemy == null)
        {
            Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _radius);
            Rigidbody rigidbody;

            for (int i = 0; i < overlappedColliders.Length; i++)
            {
                rigidbody = overlappedColliders[i].attachedRigidbody;

                Debug.Log(rigidbody);

                if (rigidbody)
                {
                    if (rigidbody.gameObject.TryGetComponent(out Enemy enemy))
                    {
                        _currentEnemy = enemy;
                        _currentEnemy.Diying += TargetKilled;

                        _shooting = StartCoroutine(Shooting());
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