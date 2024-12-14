using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    
    void Awake()
    {
        current = this;
    }

    public event Action<int, float> OnDamage;
    public void Damage(int id, float health)
    {
        if (OnDamage != null)
        {
            OnDamage(id, health);
        }
    }
}
