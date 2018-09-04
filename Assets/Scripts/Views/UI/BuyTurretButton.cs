using strange.extensions.mediation.impl;
using Signals;
using Signals.Turret;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views.UI
{
    public class BuyTurretButton : EventView
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
        public OnBuyTurretSignal OnBuyTurretSignal { get; set; }

        protected override void Start()
        {
            _buyTurretButton.onClick.AddListener(() => { OnBuyTurretSignal.Dispatch(_turretBluePrint); });
            _priceTxt.text = "$" + _turretBluePrint.BuyCost;
        }
    }
}