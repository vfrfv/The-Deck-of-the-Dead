using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 15;
    private float _timer = 2;

    private void Update()
    {
        _timer -= Time.deltaTime;
        transform.Translate(transform.forward * _speed * Time.deltaTime);

        if (_timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}