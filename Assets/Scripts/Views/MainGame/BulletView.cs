using strange.extensions.mediation.impl;
using UnityEngine;

namespace Views.MainGame
{
    public class BulletView : EventView
    {
        /// <summary>
        /// Bullet target
        /// </summary>
        private Transform _target;

        /// <summary>
        /// Bullet speed
        /// </summary>
        [SerializeField] private float _speed = 70f;

        /// <summary>
        /// Impact effect
        /// </summary>
        [SerializeField] private GameObject _impactEffect;

        private void Update()
        {
            if (_target == null)
            {
                Destroy(gameObject);
                return;
            }

            var direction = _target.position - transform.position;
            var frameDistance = _speed * Time.deltaTime;
            // If bullet hit the target
            if (direction.magnitude <= frameDistance)
            {
                HitTarget();
                return;
            }

            transform.Translate(direction.normalized * frameDistance, Space.World);
        }

        /// <summary>
        /// Seek
        /// </summary>
        /// <param name="target"></param>
        public void Seek(Transform target)
        {
            _target = target;
        }

        /// <summary>
        /// Hit target
        /// </summary>
        private void HitTarget()
        {
            // call effect on hit bullet and destroy then after second
            var effectIns = Instantiate(_impactEffect, transform.position, transform.rotation, transform.parent);
            Destroy(effectIns, 1f);
            
            Destroy(_target.gameObject);
            Destroy(gameObject);
        }
    }
}