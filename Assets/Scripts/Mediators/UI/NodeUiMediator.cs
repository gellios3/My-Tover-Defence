using Signals;
using Views.UI;

namespace Mediators.UI
{
    public class NodeUiMediator : TargetMediator<NodeUiView>
    {
        /// <summary>
        /// On build turret signal 
        /// </summary>
        [Inject]
        public OnSelectNodeSignal OnSelectNodeSignal { get; set; }

        /// <summary>
        /// On build turret signal 
        /// </summary>
        [Inject]
        public OnBuyTurretItemSignal OnBuyTurretItemSignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            OnBuyTurretItemSignal.AddListener(bluePrint => { View.HideCanvas(); });

            OnSelectNodeSignal.AddListener(view =>
            {
                if (view == View.Target)
                {
                    View.HideCanvas();
                }
                else
                {
                    View.ShowCanvas(view);
                }
            });
        }
    }
}