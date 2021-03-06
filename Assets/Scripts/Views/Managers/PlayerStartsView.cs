using strange.extensions.mediation.impl;
using Services;
using UnityEngine;

namespace Views.Managers
{
    public class PlayerStartsView : EventView
    {
        /// <summary>
        /// Start money
        /// </summary>
        [SerializeField] private int _startMoney = 400;

        /// <summary>
        /// Start lives
        /// </summary>
        [SerializeField] private int _startLives = 20;

        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

        protected override void Start()
        {
            PlayerStartsService.Money = _startMoney;
            PlayerStartsService.Lives = _startLives;
        }
    }
}