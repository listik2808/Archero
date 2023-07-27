using System.Net.NetworkInformation;
using UnityEngine;

namespace Scripts.Hero
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speedMovement;
        [SerializeField] private int _health;
        [SerializeField] private float _rateFire;
        [SerializeField] private int _damage;

        public int Money { get;private set; }

        public void OnEnemyDied(int reward)
        {
            Money += reward;
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}