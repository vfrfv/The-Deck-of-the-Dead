using System;
using UnityEngine;

public abstract class Health : MonoBehaviour 
{
    [SerializeField] protected int MaxValue;
    [SerializeField] protected int Value;

    

    public virtual void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            Value -= damage;  
        }
    }
}