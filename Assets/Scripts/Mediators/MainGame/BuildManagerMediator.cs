using Signals;
using Views.MainGame;

namespace Mediators.MainGame
{
    public class BuildManagerMediator : TargetMediator<BuildManagerView>
    {
        /// <summary>
        /// On build turret signal 
        /// </summary>
        [Inject]
        public OnBuildTurretSignal OnBuildTurretSignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            OnBuildTurretSignal.AddListener(view => { view.BuildTurret(View.transform); });
        }
    }
}