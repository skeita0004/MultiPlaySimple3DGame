using JetBrains.Annotations;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private int damage_;
    private bool isActive_;

    public void Enable(int _damage)
    {
        damage_   = _damage;
        isActive_ = true;
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

        if ( damageable != null )
        {
            return;
        }

        damageable.TakeDamage(damage_);
    }
}
