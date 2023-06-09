using System.Collections;
using Audio;
using Managers;
using Player.Abilities;
using Projectiles;
using Shared;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runes.Effects
{
    public class RageOfThor : MonoBehaviour, IRune
    {
        [SerializeField] private RuneSO originalSO;
        [SerializeField] private float radius;

        [SerializeField] private GameObject boltPrefab;
        [SerializeField] private float duration;
        [SerializeField] private float zapDelay;
    
        private RuneSO activeRune;
        private Particles _particles;
        private SoundEffect _audio;

        public void OnEnable()
        {
            activeRune = Instantiate(originalSO);
            RuneManager.Instance.AddToActiveList(activeRune);
            UIManager.Instance.EnableRageMeter();
            RageAbility.OnRage += ApplyEffect;
        }
        public void OnDisable()
        {
            RageAbility.OnRage -= ApplyEffect;
        }

        public void ApplyEffect()
        {
            StartCoroutine("Zap");
        }

        private IEnumerator Zap()
        {
            InvokeRepeating("HitAnEnemy", 1f, zapDelay);
            yield return new WaitForSeconds(duration);
            CancelInvoke("HitAnEnemy");
        }

        private void HitAnEnemy()
        {
            var enemy = GetRandomEnemy();
            if (enemy == null) return;
            InstantiateBolt(enemy.transform);
        }

        private GameObject GetRandomEnemy()
        {
            var enemies = GetEnemiesInRange();
            if (enemies.Length < 1) return null;
            var rand = Random.Range(0, enemies.Length);
            return enemies[rand].gameObject;
        }

        private void InstantiateBolt(Transform enemy)
        {
            var bolt = Instantiate(boltPrefab, transform.position + Vector3.up, Quaternion.identity);
            bolt.transform.LookAt(enemy);
            bolt.GetComponent<LightningBolt>().Damage = activeRune.effectNumber;
        }

        private Collider[] GetEnemiesInRange()
        {
            return Physics.OverlapSphere(transform.position, radius, 1 << LayerMask.NameToLayer("Enemy"));
        }
    }
}
