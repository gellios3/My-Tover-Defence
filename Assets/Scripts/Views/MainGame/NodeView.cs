using System;
using strange.extensions.mediation.impl;
using Services;
using UnityEngine;

namespace Views.MainGame
{
    public class NodeView : EventView
    {
        /// <summary>
        /// Hover color
        /// </summary>
        [SerializeField] private Color _hoverColor;

        /// <summary>
        /// Offset position for turret
        /// </summary>
        [SerializeField] private Vector3 _positionOffset;

        /// <summary>
        /// Build manager service
        /// </summary>
        [Inject]
        public BuildManagerService BuildManagerService { get; set; }

        /// <summary>
        ///  Renderer
        /// </summary>
        private Renderer _renderer;

        /// <summary>
        /// Start color
        /// </summary>
        private Color _startColor;

        /// <summary>
        /// Current turret
        /// </summary>
        public GameObject CurrentTurret { get; set; }
        
        /// <summary>
        /// Current turret
        /// </summary>
        public TurretBluePrint CurrentBluePrint { get; set; }

        /// <summary>
        /// On view update
        /// </summary>
        public event Action OnBuildTurret;

        /// <summary>
        /// On view update
        /// </summary>
        public event Action OnSelectTurret;

        /// <summary>
        /// Can build turret on node status
        /// </summary>
        public bool CanBuild => BuildManagerService.TurretToBuild != null;

        /// <summary>
        /// Has Upgraded
        /// </summary>
        public bool HasUpgraded { get; set; }

        protected override void Start()
        {
            _renderer = GetComponent<Renderer>();
            _startColor = _renderer.material.color;
        }

        private void OnMouseDown()
        {
            if (CurrentTurret != null)
            {
                OnSelectTurret?.Invoke();
                return;
            }

            OnBuildTurret?.Invoke();
        }

        private void OnMouseEnter()
        {
            if (!CanBuild)
                return;
            _renderer.material.color = _hoverColor;
        }

        private void OnMouseExit()
        {
            _renderer.material.color = _startColor;
        }

        public Vector3 GetBuildPosition()
        {
            return transform.position + _positionOffset;
        }
    }
}