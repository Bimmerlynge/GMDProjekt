using Shared;
using UnityEngine;

namespace Enemies
{
    public class EnemyController : MonoBehaviour
    {
        private static int EnemyCount = 0;
        public delegate void LastEnemyDefeatedAction();
        public static event LastEnemyDefeatedAction OnLastEnemyDefeated;
        
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            Health.OnDeathEvent += OnDeath;
        }

        private void Start()
        {
            EnemyCount++;
        }
        
        private void OnDeath(GameObject deadObj)
        {
            if (deadObj == gameObject)
            {
                _animator.SetTrigger("death");
                Invoke("Die", 0.05f);
            }
            else if (deadObj.tag.Equals("Player"))
            {
                _animator.SetTrigger("death");
                Invoke("Die", 0.05f);
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
        

        private void OnDestroy()
        {
            CheckIfLastEnemy();
            EnemyCount--;
            Health.OnDeathEvent -= OnDeath;
        }

        private void CheckIfLastEnemy()
        {
            if (EnemyCount > 1) return;
            if (OnLastEnemyDefeated != null) OnLastEnemyDefeated.Invoke();
        }
    }
}
