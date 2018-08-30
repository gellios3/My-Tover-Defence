using Services;
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
        /// On buy turret item signal
        /// </summary>
        [Inject]
        public OnBuyTurretItemSignal OnBuyTurretItemSignal { get; set; }

        /// <summary>
        /// Build manager service
        /// </summary>
        [Inject]
        public BuildManagerService BuildManagerService { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            OnBuildTurretSignal.AddListener(view => { View.BuildTurret(view); });

            OnBuyTurretItemSignal.AddListener(bluePrint => { BuildManagerService.TurretToBuild = bluePrint.Prefab; });
        }
    }
}