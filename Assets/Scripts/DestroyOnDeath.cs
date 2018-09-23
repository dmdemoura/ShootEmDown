using System;
using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    private void Start()
    {
        Health health = GetComponent<Health>();
        if (health)
            health.Death += OnDeath;
        else
            Debug.LogError("GameObject " + gameObject.name + " has no component Health but has component DestroyOnDeath");
    }
    private void OnDeath(object sender, EventArgs e)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}