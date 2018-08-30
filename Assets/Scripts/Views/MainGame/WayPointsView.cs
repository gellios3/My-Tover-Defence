using strange.extensions.mediation.impl;
using Services;

namespace Views.MainGame
{
    public class WayPointsView : EventView
    {
        /// <summary>
        /// Way points service
        /// </summary>
        [Inject]
        public WayPointsService WayPointsService { get; set; }

        protected override void Awake()
        {
            // fill way points
            WayPointsService.FillWayPoints(transform);
        }
    }
}