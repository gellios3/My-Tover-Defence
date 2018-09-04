using Signals;
using Signals.Turret;
using UnityEngine;
using Views.MainGame;

namespace Mediators.MainGame
{
    public class TurretMediator : TargetMediator<TurretView>
    {
        /// <summary>
        /// On init turret signal
        /// </summary>
        [Inject]
        public OnInitTurretSignal OnInitTurretSignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            View.OnUpdateTarget += UpdateEnemyTarget;

            View.OnRotateTurret += RotateTurret;

            View.OnShootTurret += ShootTurret;

            View.OnInit += () => { OnInitTurretSignal.Dispatch(View); };
        }

        /// <summary>
        /// Shoot turret
        /// </summary>
        private void ShootTurret()
        {
            if (View.FireCountDown <= 0)
            {
                View.Shoot();
                View.FireCountDown = 1f / View.FireRate;
            }

            View.FireCountDown -= Time.deltaTime;
        }

        /// <summary>
        /// Find enemy target direction and rotate turret head to them
        /// </summary>
        private void RotateTurret()
        {
            var direction = View.EnemyTarget.position - transform.position;
            var lookRotation = Quaternion.LookRotation(direction);
            var rotation = Quaternion.Lerp(
                View.PartToRotate.rotation, lookRotation, Time.deltaTime * View.TurnSpeed
            ).eulerAngles;
            View.PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

        /// <summary>
        /// Update enemy target
        /// </summary>
        private void UpdateEnemyTarget()
        {
            // find all enemies by tag
            var shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;
            foreach (Transform enemy in View.EnemiesParent)
            {
                var distanceToEnemy = Vector3.Distance(transform.position, enemy.position);
                // find shortest distance to enemy and nearest enemy
                if (!(distanceToEnemy < shortestDistance))
                    continue;
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy.gameObject;
            }

            // if shortest distance in attack range then set enemy target
            if (nearestEnemy != null && shortestDistance <= View.Range)
            {
                View.EnemyTarget = nearestEnemy.transform;
            }
            else
            {
                View.EnemyTarget = null;
            }
        }
    }
}