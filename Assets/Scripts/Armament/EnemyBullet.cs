using Scripts.Hero;
using UnityEngine;

namespace Assets.Scripts.Armament
{
    public class EnemyBullet : Bullet
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Player player))
            {
                player.TakeDamage(_damage);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
