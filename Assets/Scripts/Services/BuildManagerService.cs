using UnityEngine;
using Views.MainGame;

namespace Services
{
    public class BuildManagerService
    {
        /// <summary>
        /// Turret to build
        /// </summary>
        public TurretBluePrint TurretToBuild { get; set; }
        
        /// <summary>
        /// Build effect
        /// </summary>
        public GameObject BuildEffect { get; set; } 
        
        /// <summary>
        /// Sell effect
        /// </summary>
        public GameObject SellEffect { get; set; } 
    }
}