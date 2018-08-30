using UnityEngine;

namespace Services
{
    public class WayPointsService
    {
        /// <summary>
        /// Way points
        /// </summary>
        public Transform[] Points { get; set; }

        /// <summary>
        /// Fill way points service
        /// </summary>
        /// <param name="parent"></param>
        public void FillWayPoints(Transform parent)
        {
            Points = new Transform[parent.childCount];

            for (var i = 0; i < Points.Length; i++)
            {
                Points[i] = parent.GetChild(i);
            }
        }

        /// <summary>
        /// Get next way point
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetNextWayPoint(int index)
        {
            if (index >= Points.Length - 1)
            {
                return -1;
            }

            index++;
            return index;
        }
    }
}