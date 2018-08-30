using Signals;
using Views.MainGame;

namespace Mediators.MainGame
{
    public class BulletMediator : TargetMediator<BulletView>
    {
        /// <summary>
        /// On hit enemy signal
        /// </summary>
        [Inject]
        public OnHitEnemySignal OnHitEnemySignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            View.OnHitEnemy += view => { OnHitEnemySignal.Dispatch(view, View.HitDamage); };
        }
    }
}