using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator_;

    // 新規アニメーション追加手順 1 ここでハッシュ化
    private static readonly int idleHash_      = Animator.StringToHash("Idle");
    private static readonly int walkHash_      = Animator.StringToHash("Walk");
    private static readonly int runHash_       = Animator.StringToHash("Run");
    private static readonly int attack01Hash_  = Animator.StringToHash("SmallAttack01");
    private static readonly int attack02Hash_  = Animator.StringToHash("SmallAttack02");
    private static readonly int attack03Hash_  = Animator.StringToHash("SmallAttack03");

    private int currAnimHash_;

    // ２ ここでハッシュを配列に突っ込む。以上。
    private static int[] hashs_ = 
    {
        idleHash_,
        walkHash_,
        runHash_,
        attack01Hash_,
        attack02Hash_,
        attack03Hash_,
    };

    private void Awake()
    {
        animator_ = GetComponentInChildren<Animator>();
    }

    public void Play(PlayerAnimation _anim, float _fadeTime)
    {
        int nextAnimHash = hashs_[_anim.GetHashCode()];

        if (currAnimHash_ == nextAnimHash)
        {
            return;
        }

        currAnimHash_ = nextAnimHash;

        animator_.CrossFade(hashs_[_anim.GetHashCode()], _fadeTime);
    }
}
