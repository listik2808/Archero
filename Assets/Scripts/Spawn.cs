using Scripts.Enemy;
using Scripts.Enemy.StateMachine.StateEnemy;
using Scripts.Hero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemyList = new List<Enemy>();
    [SerializeField] private Collider _collider;
    private Player _player;

    private Vector3 _sizeColider = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 _min;
    private Vector3 _max;
    private Vector3 _startPosition;
    private Collider[] _colliders;
    private float _x;
    private float _z;
    private bool _check;
    private int _countEnemy;

    private void Start()
    {
        _countEnemy = _enemyList.Capacity;
        SetCoordinates();
        StartCoroutine(NewSpawn(_countEnemy));
    }

    public void SetTarget(Player target)
    {
        _player = target;
    }

    private void SetCoordinates()
    {
        _min = _collider.bounds.min;
        _max = _collider.bounds.max;
    }

    private IEnumerator NewSpawn( int count)
    {
        while (count > 0)
        {
            foreach (var item in _enemyList)
            {
                while(_check != true)
                {
                    _x = Random.Range(_min.x, _max.x);
                    _z = Random.Range(_min.z, _max.z);
                    _startPosition = new Vector3(_x, item.transform.position.y, _z);
                    _check = CheckSpawnPoint(_startPosition);
                    if (_check)
                    {
                        Enemy enemy = Instantiate(item, _startPosition, Quaternion.identity);
                        enemy.SetTargetPosition(_player);
                        count--;
                    }
                }
                _check = false;
                yield return null;
            }
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
