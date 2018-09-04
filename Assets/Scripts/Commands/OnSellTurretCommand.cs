using strange.extensions.command.impl;
using Services;
using UnityEngine;
using Views.MainGame;

namespace Commands
{
    public class OnSellTurretCommand : Command
    {
        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

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
            // sell turret
            PlayerStartsService.Money += NodeView.CurrentBluePrint.SellCost;

            // Destroy old turret
            Object.Destroy(NodeView.CurrentTurret);
            NodeView.CurrentBluePrint = null;
        }
    }
}