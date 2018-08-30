using strange.extensions.command.impl;
using Services;
using UnityEngine;

namespace Commands
{
    public class OnBuyTurretItemCommand : Command
    {
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
        public TurretBluePrint TurretBluePrint { get; set; }

        /// <summary>
        /// Execute command
        /// </summary>
        public override void Execute()
        {
            // check enough money
            if (PlayerStartsService.Money < TurretBluePrint.Cost)
            {
                Debug.Log("Not enough money!!!");
                return;
            }

            BuildManagerService.TurretToBuild = TurretBluePrint;
        }
    }
}