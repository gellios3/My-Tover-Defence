using strange.extensions.mediation.impl;
using Signals;
using UnityEngine;
using UnityEngine.UI;

namespace Views.UI
{
    public class ShopTurretItem : EventView
    {
        [SerializeField] private Button _buyTurretItem;
        
        [SerializeField] private TurretBluePrint _turretBluePrint;

        /// <summary>
        /// On buy turret item signal
        /// </summary>
        [Inject]
        public OnBuyTurretItemSignal OnBuyTurretItemSignal { get; set; }

        private void Start()
        {
            _buyTurretItem.onClick.AddListener(() => { OnBuyTurretItemSignal.Dispatch(_turretBluePrint); });
        }
    }
}