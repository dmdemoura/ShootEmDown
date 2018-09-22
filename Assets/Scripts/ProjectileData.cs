using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "Custom/Projectile", order = 1)]
public class ProjectileData : DamageOnHitData
{
    public float velocity;
}