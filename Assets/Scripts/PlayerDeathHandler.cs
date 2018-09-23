using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] private Image moduleHealthBar;
    private List<Health> moduleHealths = new List<Health>();
    private int moduleMaxHealth;
    private void Start()
    {
        Health bossHealth = GetComponent<Health>();
        if (bossHealth)
        {
            bossHealth.Death += OnBossDeath;
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            Health moduleHealth = transform.GetChild(i).GetComponentInChildren<Health>();
            if (moduleHealth)
            {
                moduleMaxHealth += moduleHealth.MaxHealth;
                moduleHealth.HealthChange += UpdateModuleHealthBar;
                moduleHealths.Add(moduleHealth);
            }
        }

    }
    private void UpdateModuleHealthBar(object sender, System.EventArgs e)
    {
        int health = 0;
        foreach (Health moduleHealth in moduleHealths)
            health += moduleHealth.HitPoints;    
        
        moduleHealthBar.fillAmount = (float) health / (float) moduleMaxHealth;
    }
    private void OnBossDeath(object sender, System.EventArgs e)
    {

    }
}