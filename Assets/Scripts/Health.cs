using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private spawnManager lv;
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    public event EventHandler Death;
    public float Percent
    {
        get
        {
            return (float) health / (float) maxHealth;
        }
    }
    private void Start(){
        lv = FindObjectOfType<spawnManager>().GetComponent<spawnManager>();
    }
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
                lv.heroiMorreu();
                Death(this, EventArgs.Empty);
            }
            else
            {
                health = value;
            }
        }
    }

}