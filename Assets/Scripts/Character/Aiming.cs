using System.Collections;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField] private float _radius;

    private int _delayBetweenShots = 3;
    private Weapon _currentWeapon;
    private Enemy _currentEnemy;
    private Coroutine _searchEnemy;

    private void Start()
    {
        _searchEnemy = StartCoroutine(SearchEnemy());
    }

    private IEnumerator Shooting()
    {
        var delay = new WaitForSeconds(_delayBetweenShots);

        if (_searchEnemy != null)
        {
            StopCoroutine(_searchEnemy);
        }

        while (_currentEnemy != null)
        {
            _currentEnemy.TakeDamage(_currentWeapon.Damage);

            yield return delay;
        }
    }

    private IEnumerator SearchEnemy()
    {
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

                        StartCoroutine(Shooting());
                    }
                }
            }

            yield return null;
        }
    }
}