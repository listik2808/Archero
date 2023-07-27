using Scripts.Enemy.StateMachine;
using Scripts.Hero;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyStateMachine _enemyStateMachine;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private int _health;
        [SerializeField] private int _damage;
        [SerializeField] private float _rateFire;
        [SerializeField] private float _stopMove;
        [SerializeField] private float _rangeMovement;
        [SerializeField] private float _speedMovement;
        [SerializeField] private int _reward;

        private Player _target;

        public Player Target => _target;

        public event Action<int> Dying;

        public void SetTargetPosition(Player target)
        {
            _target = target;
            _enemyStateMachine.SetTarget(target);
        }


        public void TakeDamage(int damage)
        {
            _health -= damage;

            if(_health <= 0)
            {
                Destroy(gameObject);
                Dying?.Invoke(_reward);
            }
        }
    }
}