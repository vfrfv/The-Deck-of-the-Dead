using System.Collections;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private ZombieSearchTarget _zombieSearchTarget;
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private int _damage;
    [SerializeField] private float _delayBetweenAttack;
    [SerializeField] private float _attackDistance;

    private Character _currentTarget;

    public bool IsAttacking { get; private set; } = false;

    private void Update()
    {
        if (_currentTarget != null)
        {
            transform.LookAt(_currentTarget.transform);
        }
    }

    public void ActivateAttack(Character enemy)
    {
        _currentTarget = enemy;
        StopCoroutine(_zombieSearchTarget.SearchTarget());
        StartCoroutine(Attacking());
    }

    private IEnumerator Attacking()
    {
        var delay = new WaitForSeconds(_delayBetweenAttack);

        float distance = Vector3.Distance(_currentTarget.transform.position, transform.position);

        if (distance < _attackDistance)
        {
            _enemyMovement.NavMeshAgent.speed = 0;
            IsAttacking = true;

            while (_currentTarget != null)
            {
                _currentTarget.TakeDamage(_damage);

                yield return delay;
            }
        }

        _currentTarget = null;
        IsAttacking = false;
        StartCoroutine(_zombieSearchTarget.SearchTarget());
    }
}