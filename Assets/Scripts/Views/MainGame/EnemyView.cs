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