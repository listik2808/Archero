using Scripts.Enemy;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Collider _collider;
    [SerializeField] private int _countEnemySpawn;

    private Vector3 _sizeColider = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 _min;
    private Vector3 _max;
    private Vector3 _startPosition;
    private Collider[] _colliders;
    private float _x;
    private float _z;
    private bool _check;

    private void Start()
    {
        SetCoordinates();
        StartCoroutine(NewSpawn(_countEnemySpawn));
    }

    private void SetCoordinates()
    {
        _min = _collider.bounds.min;
        _max = _collider.bounds.max;
    }

    private IEnumerator NewSpawn( int count)
    {
        while(count!= 0)
        {
            _x = Random.Range(_min.x, _max.x);
            _z = Random.Range(_min.z, _max.z);
            _startPosition = new Vector3(_x, 0f, _z);
            _check = CheckSpawnPoint(_startPosition);
            if (_check)
            {
                Instantiate(_enemy, _startPosition, Quaternion.identity);
                count--;
            }
            yield return null;
        }
    }

    private bool CheckSpawnPoint(Vector3 startPosition)
    {
        _colliders = Physics.OverlapBox(startPosition, _sizeColider);
        if(_colliders.Length > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
