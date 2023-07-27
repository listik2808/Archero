using Scripts.Hero;
using System;
using UnityEngine;

namespace Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
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