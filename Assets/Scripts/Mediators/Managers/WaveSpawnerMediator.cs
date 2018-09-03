using Signals;
using UnityEngine;
using Views.Managers;

namespace Mediators.Managers
{
    public class WaveSpawnerMediator : TargetMediator<WaveSpawnerView>
    {
        /// <summary>
        /// On init turret signal
        /// </summary>
        [Inject]
        public OnInitTurretSignal OnInitTurretSignal { get; set; }

        /// <summary>
        /// Game over signal
        /// </summary>
        [Inject]
        public GameOverSignal GameOverSignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            GameOverSignal.AddListener(() =>
            {
                // Destroy all enemies on game over
                foreach (Transform enemy in View.transform)
                {
                    Destroy(enemy.gameObject);
                }
            });
            
            OnInitTurretSignal.AddListener(view => { view.EnemiesParent = View.transform; });
        }
    }
}