using JetBrains.Annotations;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDamageable
{
    public int maxHP;
    public int currentHP;
    public int power;
    public int guardNum;
    public int isDead;
    public int isGuard;

    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int _damage)
    {
        currentHP -= _damage;

        if (currentHP < 0)
        {
            currentHP = 0;
        }
    }
}
