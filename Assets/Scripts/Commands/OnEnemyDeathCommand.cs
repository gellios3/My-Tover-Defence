using strange.extensions.command.impl;
using Services;
using UnityEngine;
using Views.MainGame;

namespace Commands
{
    public class OnEnemyDeathCommand : Command
    {
        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

        /// <summary>
        /// Enemy view
        /// </summary>
        [Inject]
        public EnemyView EnemyView { get; set; }

        /// <summary>
        /// Execute command
        /// </summary>
        public override void Execute()
        {
            // create death effect
            var deathEffect = Object.Instantiate(EnemyView.OnDeathEffect, EnemyView.transform.position,
                Quaternion.identity);
            Object.Destroy(deathEffect, 5f);
            
            // if heath lest zero die and increase money
            Object.Destroy(EnemyView.gameObject);
            PlayerStartsService.Money += EnemyView.CostMoney;
        }
    }
}