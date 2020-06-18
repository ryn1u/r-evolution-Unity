using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencerSpawnprojectile : MonoBehaviour
{
    public Vector2Vector2UnityEvent spawnProjectileEvent;
    public Collider2DUnityEvent hitEvent;
    public ProjectileUnityEvent missEvent;
    public ProjectilePool pool;

    public void Awake()
    {
    }
    public void SpawnProjectile(Vector2 position, Vector2 direction)
    {
        Projectile proj = pool.Get();
        proj.SetEvents(hitEvent, missEvent);
        proj.Spawn(position, direction);
    }
}
