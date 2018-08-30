using strange.extensions.mediation.impl;
using Signals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views.UI
{
    public class ShopTurretItem : EventView
    {
        /// <summary>
        /// Buy turret item
        /// </summary>
        [SerializeField] private Button _buyTurretButton;

        /// <summary>
        /// Buy turret item
        /// </summary>
        [SerializeField] private TextMeshProUGUI _priceTxt;

        /// <summary>
        /// Turret blueprint
        /// </summary>
        [SerializeField] private TurretBluePrint _turretBluePrint;

        /// <summary>
        /// On buy turret item signal
        /// </summary>
        [Inject]
        public OnBuyTurretItemSignal OnBuyTurretItemSignal { get; set; }

        protected override void Start()
        {
            _buyTurretButton.onClick.AddListener(() => { OnBuyTurretItemSignal.Dispatch(_turretBluePrint); });
            _priceTxt.text = "$" + _turretBluePrint.Cost;
        }
    }
}