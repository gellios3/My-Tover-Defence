using Signals;
using Views.MainGame;

namespace Mediators.MainGame
{
    public class NodeMediator : TargetMediator<NodeView>
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
            View.OnBuildTurret += () => { OnBuildTurretSignal.Dispatch(View); };
        }
    }
}