using strange.extensions.command.impl;
using Services;
using UnityEngine;
using Views.MainGame;

namespace Commands
{
    public class OnHitEnemyCommand : Command
    {
        /// <summary>
        /// Hit damage value
        /// </summary>
        [Inject]
        public int HitDamage { get; set; }

        /// <summary>
        /// Enemy view
        /// </summary>
        [Inject]
        public EnemyView EnemyView { get; set; }

        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

        /// <summary>
        /// Execute command
        /// </summary>
        public override void Execute()
        {
            EnemyView.Health -= HitDamage;
            
            if (EnemyView.Health >= 0)
                return;
            // if heath lest zero die and increase money
            Object.Destroy(EnemyView.gameObject);
            PlayerStartsService.Money += EnemyView.CostMoney;
        }
    }
}