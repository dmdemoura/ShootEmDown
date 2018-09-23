using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    private bool isDead = false;
    public event EventHandler HealthChange;
    public event EventHandler Death;
    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }
    public float Percent
    {
        get
        {
            return (float) health / (float) maxHealth;
        }
    } 
    public int HitPoints
    {
        get
        {
            return health;
        }
        set
        {
            if (!isDead)
            {
                if (value > maxHealth)
                {
                    health = maxHealth;
                }
                else if (value < 0)
                {
                    health = 0;
                    isDead = true;
                    Death(this, EventArgs.Empty);
                }
                else
                {
                    health = value;
                }
                HealthChange(this, EventArgs.Empty);
            }
        }
    }

}