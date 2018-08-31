using strange.extensions.mediation.impl;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Views.UI
{
    public class GameOverView : EventView
    {
        /// <summary>
        /// Game over content
        /// </summary>
        [SerializeField] private GameObject _gameOverContent;

        /// <summary>
        /// Game over content
        /// </summary>
        [SerializeField] private Button _retryBtn;

        /// <summary>
        /// Rounds survived txt
        /// </summary>
        [SerializeField] private TextMeshProUGUI _roundsSurvivedTxt;

        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

        protected override void Start()
        {
            _retryBtn.onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); });
        }

        /// <summary>
        /// Show game over content
        /// </summary>
        public void ShowGameOver()
        {
            _roundsSurvivedTxt.text = PlayerStartsService.Rounds.ToString();
            _gameOverContent.SetActive(true);
        }
    }
}