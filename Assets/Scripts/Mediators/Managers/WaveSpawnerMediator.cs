using Signals;
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
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            OnInitTurretSignal.AddListener(view => { view.EnemiesParent = View.transform; });
        }
    }
}