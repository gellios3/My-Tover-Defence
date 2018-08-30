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
        
        public Vector3 PositionOffset => _positionOffset;

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
        public GameObject CurrentTurret { private get; set; }

        /// <summary>
        /// On view update
        /// </summary>
        public event Action OnBuildTurret;

        /// <summary>
        /// Can build turret on node status
        /// </summary>
        public bool CanBuild => BuildManagerService.TurretToBuild != null;

        protected override void Start()
        {
            _renderer = GetComponent<Renderer>();
            _startColor = _renderer.material.color;
        }

        private void OnMouseDown()
        {
            if (CurrentTurret != null)
            {
                //@TODO Display on UI  
                Debug.Log("Can't build there!!");
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
       
    }
}