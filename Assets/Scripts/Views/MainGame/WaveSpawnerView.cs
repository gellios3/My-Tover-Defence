using System.Collections;
using strange.extensions.mediation.impl;
using Services;
using TMPro;
using UnityEngine;

namespace Views.MainGame
{
    public class WaveSpawnerView : EventView
    {
        /// <summary>
        /// Enemy prefab
        /// </summary>
        [SerializeField] private Transform _enemyPrefab;
        
        /// <summary>
        /// Enemies parent
        /// </summary>
        [SerializeField] private Transform _enemiesParent;
        
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

        private void Update()
        {
            if (_countDown <= 0f)
            {
                StartCoroutine(SpawnWave());
                _countDown = _timeBetweenWaves;
            }

            _countDown -= Time.deltaTime;
            // set countDown to UI text
            _waveCountDownTimerTxt.text = Mathf.Round(_countDown).ToString();
        }

        /// <summary>
        /// Spawn wave
        /// </summary>
        private IEnumerator SpawnWave()
        {
            WaveService.WaveIndex++;
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
            Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation, _enemiesParent);
        }
    }
}