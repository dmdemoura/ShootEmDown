using UnityEngine;

public class Projectile : DamageOnHit
{
    public static void Fire(GameObject projectilePrefab, ProjectileData projectileData, Vector3 position, Quaternion rotation)
    {
        GameObject projectileObj = Instantiate(projectilePrefab, position, rotation);
        Projectile projectile = projectileObj.AddComponent<Projectile>();
        projectile.Init(projectileData);
    }
    protected void Init(ProjectileData projectileData)
    {
        Init((DamageOnHitData) projectileData);
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D)
            rigidbody2D.velocity = new Vector2(0f, projectileData.velocity);
        else
            Debug.Log("Projectile has no Rigidbody component");       
    }
}