using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Views.MainGame
{
    public class TurretView : EventView
    {
        /// <summary>
        /// Enemy target
        /// </summary>
        [SerializeField] private Transform _enemyTarget;

        public Transform EnemyTarget
        {
            get { return _enemyTarget; }
            set { _enemyTarget = value; }
        }

        /// <summary>
        /// Attack range
        /// </summary>
        [Header("Attributes")] [SerializeField]
        private float _range = 15f;

        public float Range => _range;

        /// <summary>
        /// Fire rate
        /// </summary>
        [SerializeField] private float _fireRate = 1f;

        public float FireRate => _fireRate;

        /// <summary>
        /// Turn speed
        /// </summary>
        [Header("Setup Fields")] [SerializeField]
        private float _turnSpeed = 10f;

        public float TurnSpeed => _turnSpeed;

        /// <summary>
        /// Part to rotate
        /// </summary>
        [SerializeField] private Transform _partToRotate;

        public Transform PartToRotate => _partToRotate;

        /// <summary>
        ///  Enemies parent
        /// </summary>
        public Transform EnemiesParent { get; set; }

        /// <summary>
        /// Bullet prefab
        /// </summary>
        [SerializeField] private GameObject _bulletPrefab;

        /// <summary>
        /// Fire point
        /// </summary>
        [SerializeField] private Transform _firePoint;

        /// <summary>
        /// Fire count down
        /// </summary>
        public float FireCountDown { get; set; }

        /// <summary>
        /// On update target
        /// </summary>
        public event Action OnUpdateTarget;

        /// <summary>
        /// On init
        /// </summary>
        public event Action OnInit;

        /// <summary>
        /// On rotate turret
        /// </summary>
        public event Action OnRotateTurret;

        /// <summary>
        /// On rotate turret
        /// </summary>
        public event Action OnShootTurret;

        protected override void Start()
        {
            OnInit?.Invoke();
            InvokeRepeating(nameof(UpdateTarget), 0, 0.5f);
            base.Start();
        }

        private void Update()
        {
            if (EnemyTarget == null)
                return;
            OnRotateTurret?.Invoke();

            OnShootTurret?.Invoke();
        }

        /// <summary>
        /// On draw range Gizmo
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Range);
        }

        /// <summary>
        /// Call update target
        /// </summary>
        private void UpdateTarget()
        {
            OnUpdateTarget?.Invoke();
        }

        /// <summary>
        /// Shot bullet
        /// </summary>
        public void Shoot()
        {
            var bulletGo = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            var bullet = bulletGo.GetComponent<BulletView>();

            if (bullet != null)
            {
                bullet.Seek(_enemyTarget);
            }
        }
    }
}