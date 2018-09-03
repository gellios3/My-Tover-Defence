using strange.extensions.mediation.impl;
using Signals;
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
        /// On build turret signal 
        /// </summary>
        [Inject]
        public OnUpgradeTurretSignal OnUpgradeTurretSignal { get; set; }

        protected override void Start()
        {
            HideCanvas();

            _upgradeBtn.onClick.AddListener(() =>
            {
                OnUpgradeTurretSignal.Dispatch(_target);
                _upgradeBtn.gameObject.SetActive(false);
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

            transform.position = Target.GetBuildPosition();
            _childCanvas.SetActive(true);
        }
    }
}