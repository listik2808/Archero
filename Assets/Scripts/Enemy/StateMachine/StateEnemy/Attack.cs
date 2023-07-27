using Assets.Scripts.Armament;
using UnityEngine;

namespace Scripts.Enemy.StateMachine.StateEnemy
{
    public class Attack : State
    {
        [SerializeField] private EnemyBullet _bullet;
        [SerializeField] private Transform _pointFire;

        private float _elepsedTime = 0;
        private float _timeShot = 0;
        private EnemyBullet bullet;
        Vector3 _point;

        private void Update()
        {
            _elepsedTime += Time.deltaTime;

            if (IsActive && Target!= null && _elepsedTime < _enemy.StopMove)
            {
                _timeShot += Time.deltaTime;
                Target = _enemy.Target.transform;
                _agent.transform.LookAt(Target.transform.position);
                if(_enemy.RateFire <= _timeShot)
                {
                    CreateBulet();
                }

            }
        }

        private void CreateBulet()
        {
            EnemyBullet bullet = Instantiate(_bullet,_pointFire);
            bullet.transform.parent = null;
            _timeShot = 0;
        }
    }
}
