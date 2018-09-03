using strange.extensions.mediation.impl;
using UnityEngine;
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

        protected override void Start()
        {
            HideCanvas();
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
            transform.position = Target.GetBuildPosition();
            _childCanvas.SetActive(true);
        }
    }
}