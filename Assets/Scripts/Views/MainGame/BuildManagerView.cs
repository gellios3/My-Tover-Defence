using strange.extensions.mediation.impl;
using Services;
using UnityEngine;

namespace Views.MainGame
{
    public class BuildManagerView : EventView
    {
        /// <summary>
        /// Build manager service
        /// </summary>
        [Inject]
        public BuildManagerService BuildManagerService { get; set; }

        /// <summary>
        /// Build turret
        /// </summary>
        public void BuildTurret(NodeView node)
        {
            // Build a turret
            if (!node.CanBuild)
                return;
            var turretToBuild = BuildManagerService.TurretToBuild;
            node.CurrentTurret = Instantiate(
                turretToBuild, node.transform.position + node.PositionOffset, Quaternion.identity, transform
            );
            BuildManagerService.TurretToBuild = null;
        }
    }
}