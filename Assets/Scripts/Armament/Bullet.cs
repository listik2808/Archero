using UnityEngine;

namespace Assets.Scripts.Armament
{
    public abstract partial class Bullet: MonoBehaviour
    {
        [SerializeField] protected int _damage;
        [SerializeField] protected float _speed;

        public float Speed => _speed;

        private void Update()
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
    }
}
