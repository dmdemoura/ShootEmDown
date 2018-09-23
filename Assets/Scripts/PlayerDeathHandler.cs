using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] private Image moduleHealthBar;
    [SerializeField] private GameObject explosionPrefab;
    private List<Health> moduleHealths = new List<Health>();
    private int moduleMaxHealth;
    int exI;
    float time = 1f;
    float scale = 1f;
    int bI = 0;
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
            if (moduleHealth) health += moduleHealth.HitPoints;    
        
        moduleHealthBar.fillAmount = (float) health / (float) moduleMaxHealth;
    }
    private void OnBossDeath(object sender, System.EventArgs e)
    {
        Invoke("EXPLOSIONS", time);
    }
    private void EXPLOSIONS()
    {
        if (exI < moduleHealths.Count)
        {
            Instantiate(explosionPrefab, moduleHealths[exI].gameObject.transform.position, Quaternion.identity);
            Destroy(moduleHealths[exI].gameObject);
            exI++;
            time -= 0.1f;
            Invoke("EXPLOSIONS", time);
        }
        else
        {
            time = 0.2f;
            Invoke("MOAREXPLOSIONS", time);
        }
    }
    private void MOAREXPLOSIONS()
    {
        if (exI < 50)
        {
            Vector3 v = transform.position + new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f), 0f); 
            GameObject obj =Instantiate(explosionPrefab, v, Quaternion.identity);
            obj.transform.localScale = new Vector3(.8f,.8f,.8f);
            Invoke("MOAREXPLOSIONS", time);
        }
        else
        {
            Invoke("BIGEXPLOSIONS", 1f);
        }
        exI++;
    }
    private void BIGEXPLOSIONS()
    {
        if (bI < 3)
        {
            GameObject obj = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            obj.transform.localScale = new Vector3(scale, scale, scale);
            scale += 0.5f;
            Invoke("BIGEXPLOSIONS", .5f);
            bI++;
        }
        else
        {
            SceneManager.LoadScene("YouWin");
        }
    }
}
