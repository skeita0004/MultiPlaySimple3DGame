using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator_;
    public  PlayerAnimation currentAnimation;

    // 新規アニメーション追加手順 1 ここでハッシュ化
    private static readonly int idleHash_          = Animator.StringToHash("Idle");
    private static readonly int walkHash_          = Animator.StringToHash("Walk");
    private static readonly int runHash_           = Animator.StringToHash("Run");
    private static readonly int attack01Hash_      = Animator.StringToHash("SmallAttack01");
    private static readonly int attack02Hash_      = Animator.StringToHash("SmallAttack02");
    private static readonly int attack03Hash_      = Animator.StringToHash("SmallAttack03");
    private static readonly int deadHash_          = Animator.StringToHash("Dead");
    private static readonly int guardIdleHash_     = Animator.StringToHash("GuardIdle");
    private static readonly int guardReactionHash_ = Animator.StringToHash("GuardReaction");

    private int currAnimHash_;

    // ２ ここでハッシュを配列に突っ込む。
    private static int[] hashs_ = 
    {
        idleHash_,
        walkHash_,
        runHash_,
        attack01Hash_,
        attack02Hash_,
        attack03Hash_,
        deadHash_,
        guardIdleHash_,
        guardReactionHash_,
    };

    private void Awake()
    {
        animator_ = GetComponentInChildren<Animator>();
    }

    public void Play(PlayerAnimation _anim, float _fadeTime)
    {
        currentAnimation = _anim;

        int nextAnimHash = hashs_[_anim.GetHashCode()];

        if (currAnimHash_ == nextAnimHash)
        {
            return;
        }

        currAnimHash_ = nextAnimHash;

        animator_.CrossFade(hashs_[_anim.GetHashCode()], _fadeTime);
    }

    public float GetNormalizedTime()
    {
        AnimatorStateInfo info = animator_.GetCurrentAnimatorStateInfo(0);

        return info.normalizedTime;
    }
}
