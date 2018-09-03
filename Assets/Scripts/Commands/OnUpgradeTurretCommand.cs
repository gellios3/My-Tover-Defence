using strange.extensions.command.impl;
using Services;
using Signals;
using UnityEngine;
using Views.MainGame;

namespace Commands
{
    public class OnUpgradeTurretCommand : Command
    {
        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public OnBuildUpdateTurretSignal OnBuildUpdateTurretSignal { get; set; }    
        
        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

        /// <summary>
        /// Build manager service
        /// </summary>
        [Inject]
        public BuildManagerService BuildManagerService { get; set; }

        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public NodeView NodeView { get; set; }

        /// <summary>
        /// Execute command
        /// </summary>
        public override void Execute()
        {
            // check enough money
            if (PlayerStartsService.Money < NodeView.CurrentBluePrint.UpdateCost)
            {
                Debug.Log("Not enough money to UPGRADE them!!!");
                return;
            }

            // sell turret
            PlayerStartsService.Money -= NodeView.CurrentBluePrint.UpdateCost;

            // Destroy old turret
            Object.Destroy(NodeView.CurrentTurret);

            NodeView.HasUpgraded = true;
            BuildManagerService.TurretToBuild = NodeView.CurrentBluePrint;
            
            OnBuildUpdateTurretSignal.Dispatch(NodeView);
        }
    }
}