using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    public event EventHandler Death;
    public int HitPoints
    {
        get
        {
            return health;
        }
        set
        {
            if (value > maxHealth)
            {
                health = maxHealth;
            }
            else if (value < 0)
            {
                health = 0;
                Death(this, EventArgs.Empty);
            }
            else
            {
                health = value;
            }
        }
    }

}