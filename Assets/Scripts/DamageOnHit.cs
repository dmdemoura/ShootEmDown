using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] protected string enemyTag;
    [SerializeField] private bool dieOnHit;
    [SerializeField] private GameObject explosionPrefab;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {
            Health health = other.gameObject.GetComponent<Health>();
            if (health)
                health.HitPoints -= damage;
            else
                Debug.LogWarning("DamageOnHit collided with enemy that has no health component");
            if (dieOnHit)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}