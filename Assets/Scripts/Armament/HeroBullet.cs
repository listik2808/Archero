using Scripts.Enemy;
using UnityEngine;

namespace Assets.Scripts.Armament
{
    public abstract partial class Bullet
    {
        public class HeroBullet : Bullet
        {
            private void OnTriggerEnter(Collider other)
            {
                if (other.gameObject.TryGetComponent(out Enemy enemy))
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
}
