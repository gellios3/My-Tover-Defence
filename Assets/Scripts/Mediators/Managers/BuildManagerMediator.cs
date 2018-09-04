using Signals;
using Signals.Turret;
using UnityEngine;
using Views.Managers;

namespace Mediators.Managers
{
    public class BuildManagerMediator : TargetMediator<BuildManagerView>
    {
        /// <summary>
        /// On build turret signal 
        /// </summary>
        [Inject]
        public OnBuildTurretSignal OnBuildTurretSignal { get; set; }

        /// <summary>
        /// On build turret signal 
        /// </summary>
        [Inject]
        public OnBuildUpdateTurretSignal OnBuildUpdateTurretSignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            OnBuildTurretSignal.AddListener(view => { View.BuildTurret(view); });

            OnBuildUpdateTurretSignal.AddListener(view => { View.BuildUpgradeTurret(view); });
        }
    }
}