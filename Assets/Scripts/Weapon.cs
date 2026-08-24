using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Hitbox hitbox_;

    [SerializeField]
    private int damage_ = 10;

    public void Attack()
    {
        hitbox_.Enable(damage_);
    }

    public void CancelAttack()
    {
        hitbox_.Disable();
    }
}
