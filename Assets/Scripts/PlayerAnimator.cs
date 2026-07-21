using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator_;

    private static readonly int idleHash_ = Animator.StringToHash("Idle");
    private static readonly int walkHash_ = Animator.StringToHash("Walk");
    private static readonly int runHash_  = Animator.StringToHash("Run");

    private int currAnimHash_;

    private static int[] hashs_ = 
    {
        idleHash_,
        walkHash_,
        runHash_,
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
