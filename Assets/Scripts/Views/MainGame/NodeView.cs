using System;
using strange.extensions.mediation.impl;
using Services;
using Signals;
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
        ///  Renderer
        /// </summary>
        private Renderer _renderer;

        /// <summary>
        /// Start color
        /// </summary>
        private Color _startColor;

        public GameObject Turret { get; set; }

        /// <summary>
        /// On view update
        /// </summary>
        public event Action OnBuildTurret;

        protected override void Start()
        {
            _renderer = GetComponent<Renderer>();
            _startColor = _renderer.material.color;
        }

        private void OnMouseDown()
        {
            if (Turret != null)
            {
                //@TODO Display on UI  
                Debug.Log("Can't build there!!");
                return;
            }

            OnBuildTurret?.Invoke();
        }

        private void OnMouseEnter()
        {
            _renderer.material.color = _hoverColor;
        }

        private void OnMouseExit()
        {
            _renderer.material.color = _startColor;
        }

        /// <summary>
        /// Build turret
        /// </summary>
        public void BuildTurret(Transform parent)
        {
            var prefab = Resources.Load("Prefabs/StandardTurret", typeof(GameObject));
            Turret = (GameObject) Instantiate(prefab, transform.position + _positionOffset, transform.rotation, parent);
        }
    }
}