using strange.extensions.mediation.impl;
using Services;
using TMPro;
using UnityEngine;

namespace Views.UI
{
    public class MoneyStatusTxt : EventView
    {
        /// <summary>
        /// Money text
        /// </summary>
        [SerializeField] private TextMeshProUGUI _moneyTxt;

        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

        private void Update()
        {
            _moneyTxt.text = "$" + PlayerStartsService.Money;
        }
    }
}