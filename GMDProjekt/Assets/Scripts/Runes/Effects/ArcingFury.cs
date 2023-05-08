using System.Collections;
using System.Collections.Generic;
using Abilities;
using Projectiles;
using UnityEngine;

public class ArcingFury : MonoBehaviour, IRune
{
    [SerializeField] private RuneSO originalSO;
    [SerializeField] private float radius;
    [SerializeField] private Transform hitZone;
    [SerializeField] private GameObject boltPrefab;

    private List<Collider> enemies;
    private RuneSO activeRune;

    public void OnEnable()
    {
        activeRune = Instantiate(originalSO);
        RuneManager.Instance.AddToActiveList(activeRune);
        AttackAbility.OnAttack += ApplyEffect;
    }

    public void ApplyEffect()
    {

        var enemy = GetEnemy(hitZone, radius);
        if (enemy == null) return;
        
        InstantiateBolt(transform, enemy);
        var nextEnemy = GetEnemy(enemy, 20f);
        if (nextEnemy == null) return;
        InstantiateBolt(enemy, nextEnemy);

    }


    private void InstantiateBolt(Transform start, Transform target)
    {
        print("bolt should be spawned");
        var bolt = Instantiate(boltPrefab, start.position, Quaternion.identity);
        bolt.transform.LookAt(target);
        bolt.GetComponent<LightningBolt>().Damage = activeRune.effectNumber;
    }

    private Transform GetEnemy(Transform start, float range)
    {
        var enemiesInRange = GetEnemiesInRange(start, range);
        if (enemiesInRange.Length < 1) return null;
        var rand = Random.Range(0, enemiesInRange.Length);
        return enemiesInRange[rand].transform;
    }

    private Collider[] GetEnemiesInRange(Transform start, float range)
    {
        return Physics.OverlapSphere(start.position, range, 1 << LayerMask.NameToLayer("Enemy"));
    }
    
    

    
    

    public void OnDisable()
    {
        AttackAbility.OnAttack -= ApplyEffect;
    }
}
