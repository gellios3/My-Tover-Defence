using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Views.MainGame
{
    public class EnemyView : EventView
    {
        /// <summary>
        /// Enemy speed
        /// </summary>
        [SerializeField] private float _speed = 10f;

        public float Speed => _speed;

        /// <summary>
        /// On death effect
        /// </summary>
        [SerializeField] private GameObject _onDeathEffect;
        
        public GameObject OnDeathEffect => _onDeathEffect;

        /// <summary>
        /// Current way point
        /// </summary>
        [SerializeField] private Transform _currentWayPoint;

        public Transform CurrentWayPoint
        {
            get { return _currentWayPoint; }
            set { _currentWayPoint = value; }
        }

        /// <summary>
        /// Current way point index
        /// </summary>
        public int WayPointIndex { get; set; }

        /// <summary>
        /// Health
        /// </summary>
        public int Health { get; set; } = 100;

        /// <summary>
        /// Cost money on die
        /// </summary>
        [SerializeField] private int _costMoney  = 50;
        
        public int CostMoney => _costMoney;
     

        /// <summary>
        /// On init view
        /// </summary>
        public event Action OnInit;

        /// <summary>
        /// On view update
        /// </summary>
        public event Action OnUpdate;

        protected override void Start()
        {
            OnInit?.Invoke();
        }

        private void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}