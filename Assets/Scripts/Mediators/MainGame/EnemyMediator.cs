using Services;
using Signals;
using UnityEngine;
using Views.MainGame;

namespace Mediators.MainGame
{
    public class EnemyMediator : TargetMediator<EnemyView>
    {
        /// <summary>
        /// Way points service
        /// </summary>
        [Inject]
        public WayPointsService WayPointsService { get; set; }

        /// <summary>
        /// On hit player signal
        /// </summary>
        [Inject]
        public OnHitPlayerSignal OnHitPlayerSignal { get; set; }

        /// <summary>
        /// Check distance
        /// </summary>
        private const float CheckDistance = 0.4f;

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            View.OnInit += () => { View.CurrentWayPoint = WayPointsService.Points[0]; };

            View.OnUpdate += SeekAndGoToWayPoint;
        }

        /// <summary>
        /// Seek and go to way point
        /// </summary>
        private void SeekAndGoToWayPoint()
        {
            // go to next target
            var deltaPosition = View.CurrentWayPoint.position - View.transform.position;
            transform.Translate(deltaPosition.normalized * View.Speed * Time.deltaTime, Space.World);
            // get next way point if enemy near current
            if (!(Vector3.Distance(transform.position, View.CurrentWayPoint.position) <= CheckDistance))
                return;
            View.WayPointIndex = WayPointsService.GetNextWayPoint(View.WayPointIndex);
            if (View.WayPointIndex != -1)
            {
                View.CurrentWayPoint = WayPointsService.Points[View.WayPointIndex];
            }
            else
            {
                // if last way point destroy enemy
                OnHitPlayerSignal.Dispatch();
                Destroy(View.gameObject);
            }
        }
    }
}