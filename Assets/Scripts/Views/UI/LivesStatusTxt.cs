using strange.extensions.mediation.impl;
using Services;
using TMPro;
using UnityEngine;

namespace Views.UI
{
    public class LivesStatusTxt : EventView
    {
        /// <summary>
        /// Lives text
        /// </summary>
        [SerializeField] private TextMeshProUGUI _livesTxt;

        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

        private void Update()
        {
            _livesTxt.text = PlayerStartsService.Lives + " LIVES";
        }
    }
}