using strange.extensions.mediation.impl;
using Signals;
using Signals.Turret;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Views.MainGame;

namespace Views.UI
{
    public class NodeUiView : EventView
    {
        /// <summary>
        /// Selected node
        /// </summary>
        [SerializeField] private NodeView _target;

        public NodeView Target => _target;

        /// <summary>
        /// Child canvas
        /// </summary>
        [SerializeField] private GameObject _childCanvas;

        /// <summary>
        /// Upgrade Btn
        /// </summary>
        [SerializeField] private Button _upgradeBtn;

        /// <summary>
        /// Upgrade Btn
        /// </summary>
        [SerializeField] private TextMeshProUGUI _upgradeCost;

        /// <summary>
        /// Upgrade Btn
        /// </summary>
        [SerializeField] private Button _sellBtn;

        /// <summary>
        /// Upgrade Btn
        /// </summary>
        [SerializeField] private TextMeshProUGUI _sellCost;

        /// <summary>
        /// On build turret signal 
        /// </summary>
        [Inject]
        public OnUpgradeTurretSignal OnUpgradeTurretSignal { get; set; }

        /// <summary>
        /// On build turret signal 
        /// </summary>
        [Inject]
        public OnSellTurretSignal OnSellTurretSignal { get; set; }

        protected override void Start()
        {
            HideCanvas();

            _upgradeBtn.onClick.AddListener(() =>
            {
                OnUpgradeTurretSignal.Dispatch(_target);
                _upgradeBtn.gameObject.SetActive(false);
                HideCanvas();
            });

            _sellBtn.onClick.AddListener(() =>
            {
                OnSellTurretSignal.Dispatch(_target);
                HideCanvas();
            });
        }

        /// <summary>
        /// Hide canvas
        /// </summary>
        public void HideCanvas()
        {
            _childCanvas.SetActive(false);
            _target = null;
        }

        /// <summary>
        /// Show canvas
        /// </summary>
        public void ShowCanvas(NodeView view)
        {
            _target = view;

            // show update button if not updated
            _upgradeBtn.gameObject.SetActive(!_target.HasUpgraded);

            // Set update and sell cost from blueprint 
            _upgradeCost.text = "$" + _target.CurrentBluePrint.UpdateCost;
            _sellCost.text = "$" + _target.CurrentBluePrint.SellCost;

            transform.position = Target.GetBuildPosition();
            _childCanvas.SetActive(true);
        }
    }
}