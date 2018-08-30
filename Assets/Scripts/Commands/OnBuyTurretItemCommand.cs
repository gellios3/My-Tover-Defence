
using strange.extensions.command.impl;
using UnityEngine;

namespace Commands
{
    public class OnBuyTurretItemCommand : Command
    {
        /// <summary>
        /// Execute command
        /// </summary>
        public override void Execute()
        {
            Debug.Log("OnBuyTurretItemCommand");
        }
    }
}