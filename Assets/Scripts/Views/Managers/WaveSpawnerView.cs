using System;
using System.Collections;
using strange.extensions.mediation.impl;
using Services;
using TMPro;
using UnityEngine;

namespace Views.Managers
{
    public class WaveSpawnerView : EventView
    {
        /// <summary>
        /// Enemy prefab
        /// </summary>
        [SerializeField] private Transform _enemyPrefab;

        /// <summary>
        /// Spawn point
        /// </summary>
        [SerializeField] private Transform _spawnPoint;

        /// <summary>
        /// Wave count down timer
        /// </summary>
        [SerializeField] private TextMeshProUGUI _waveCountDownTimerTxt;

        /// <summary>
        /// Time between waves
        /// </summary>
        [SerializeField] private float _timeBetweenWaves = 5f;

        /// <summary>
        /// Count down
        /// </summary>
        private float _countDown = 2f;

        /// <summary>
        /// Spawn interval
        /// </summary>
        private const float SpawnInterval = 0.5f;

        /// <summary>
        /// Wave service
        /// </summary>
        [Inject]
        public WaveService WaveService { get; set; }

        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

        private void Update()
        {
            if (PlayerStartsService.HasGameOver)
                return;

            if (_countDown <= 0f)
            {
                StartCoroutine(SpawnWave());
                _countDown = _timeBetweenWaves;
            }

            _countDown -= Time.deltaTime;
            // set countDown to UI text
            _countDown = Mathf.Clamp(_countDown, 0f, Mathf.Infinity);
            _waveCountDownTimerTxt.text = $"{_countDown:0.00}";
        }

        /// <summary>
        /// Spawn wave
        /// </summary>
        private IEnumerator SpawnWave()
        {
            WaveService.WaveIndex++;
            PlayerStartsService.Rounds++;
            for (var i = 0; i < WaveService.WaveIndex; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(SpawnInterval);
            }
        }

        /// <summary>
        /// Spawn enemy
        /// </summary>
        private void SpawnEnemy()
        {
            // Load Enemy prefab
            Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation, transform);
        }
    }
}