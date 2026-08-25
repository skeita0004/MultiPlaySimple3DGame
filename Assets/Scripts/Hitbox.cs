using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private int damage_;
    private bool isActive_;
    private readonly HashSet<IDamageable> hitTargets_ = new HashSet<IDamageable>();


    public void Enable(int _damage)
    {
        damage_   = _damage;
        isActive_ = true;

        hitTargets_.Clear();
    }

    public void Disable()
    {
        isActive_ = false;
    }

    public void OnTriggerEnter(Collider _other)
    {
        if ( isActive_ == false )
        {
            return;
        }

        IDamageable damageable = _other.GetComponent<IDamageable>();

        if ( damageable == null )
        {
            return;
        }

        if (_other.name == "Player")
        {
            return;
        }

        if (hitTargets_.Contains(damageable))
        {
            return;
        }

        hitTargets_.Add(damageable);

        damageable.TakeDamage(damage_);
    }
}
