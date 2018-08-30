using strange.extensions.mediation.impl;
using Services;
using UnityEngine;

namespace Views.MainGame
{
    public class BuildManagerView : EventView
    {
        /// <summary>
        /// Standard turret prefab
        /// </summary>
        [SerializeField] private GameObject _standardTurretPrefab;

        /// <summary>
        /// Build manager service
        /// </summary>
        [Inject]
        public BuildManagerService BuildManagerService { get; set; }

        protected override void Start()
        {
            BuildManagerService.TurretToBuild = _standardTurretPrefab;
        }

        
    }
}