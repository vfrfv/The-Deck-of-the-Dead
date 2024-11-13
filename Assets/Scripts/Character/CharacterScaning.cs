using System.Collections;
using UnityEngine;

public class CharacterScaning : MonoBehaviour
{
    [SerializeField] private CharacterShooting _characterShooting;
    [SerializeField] private float _radius;

    private Enemy _currentEnemy;

    private void OnEnable()
    {
        StartCoroutine(SearchEnemy());
    }

    private void OnDisable()
    {
        StopCoroutine(SearchEnemy());
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
                        _characterShooting.ActivShooting(_currentEnemy);
                        this.enabled = false;
                    }
                }
            }

            yield return null;
        }
    }
}