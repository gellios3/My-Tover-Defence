using strange.extensions.mediation.impl;
using Services;
using UnityEngine;
using Views.MainGame;

namespace Views.Managers
{
    public class BuildManagerView : EventView
    {
        /// <summary>
        /// Build manager service
        /// </summary>
        [Inject]
        public BuildManagerService BuildManagerService { get; set; }

        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

        /// <summary>
        /// Build turret
        /// </summary>
        public void BuildTurret(NodeView node)
        {
            // Build a turret
            if (!node.CanBuild)
                return;

            var turretToBuild = BuildManagerService.TurretToBuild;

            // sell turret
            PlayerStartsService.Money -= turretToBuild.BuyCost;

            node.CurrentBluePrint = turretToBuild;

            // Instantiate new turret
            node.CurrentTurret = Instantiate(
                turretToBuild.Prefab, node.GetBuildPosition(), Quaternion.identity, transform
            );
            BuildManagerService.TurretToBuild = null;

            Debug.Log("Money :" + PlayerStartsService.Money);
        }

        /// <summary>
        /// Build upgrade turret
        /// </summary>
        /// <param name="node"></param>
        public void BuildUpgradeTurret(NodeView node)
        {
            var turretToBuild = BuildManagerService.TurretToBuild;
            
            node.CurrentTurret = Instantiate(
                turretToBuild.UpgradePrefab, node.GetBuildPosition(), Quaternion.identity, transform
            );
            
            BuildManagerService.TurretToBuild = null;
            
            Debug.Log("Money :" + PlayerStartsService.Money);
        }
    }
}