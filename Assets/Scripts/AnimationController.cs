using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator _characterAnimator;

    public void WalkAnimation(float walkSpeed)
    {
        _characterAnimator.SetFloat("Walk", walkSpeed);
    }

    public void MeleeAttack()
    {
        _characterAnimator.SetTrigger("MeleeAttack");
    }
}
