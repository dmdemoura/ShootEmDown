using System;
using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    private void Start()
    {
        Health health = GetComponent<Health>();
        health.Death += OnDeath;
    }
    private void OnDeath(object sender, EventArgs e)
    {
        Destroy(gameObject);
    }
}