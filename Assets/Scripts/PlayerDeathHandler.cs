using UnityEngine;
using UnityEngine.UI;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] private Image moduleHealthBar;
    private Health[] moduleHealths;
    private int moduleMaxHealth;
    private void Start()
    {
        Health bossHealth = GetComponent<Health>();
        if (bossHealth)
        {
            bossHealth.Death += OnBossDeath;
        }
        moduleHealths =  GetComponentsInChildren<Health>();
        foreach (Health moduleHealth in moduleHealths)
        {
            Debug.Log("hai");
            moduleMaxHealth += moduleHealth.MaxHealth;
            moduleHealth.HealthChange += UpdateModuleHealthBar;
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