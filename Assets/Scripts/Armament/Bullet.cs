using Scripts.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Armament
{
    public class Bullet: MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(_damage);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
