using Managers;
using UnityEngine;

namespace Enemies.Melee
{
    public class Spider : MonoBehaviour
    {
        [SerializeField] private GameObject spiderSpawn;
        [SerializeField] private int amount;

        private void OnDisable()
        {
            if (!GameStateHandler.Instance.IsSpawnSafe) return;
            SpawnMinions();
        }

        private void SpawnMinions()
        {
            for (int i = 0; i < amount; i++)
            {
                Instantiate(spiderSpawn, transform.position, Quaternion.identity);
            }
        }
    }
}
