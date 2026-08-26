using JetBrains.Annotations;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDamageable
{
    public int maxHP;
    public int currentHP;
    public int power;
    public int maxGuardLimit;
    public int guardLimit;
    public bool isDead;
    public bool isGuard;

    void Start()
    {
        currentHP = maxHP;
        guardLimit = maxGuardLimit;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int _damage)
    {
        if (isGuard)
        {
            return;
        }

        currentHP -= _damage;

        if (currentHP < 0)
        {
            currentHP = 0;
        }

        Debug.Log(currentHP);
    }
}
