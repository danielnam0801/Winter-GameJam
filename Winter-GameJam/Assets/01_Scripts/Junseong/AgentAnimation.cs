using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimation : MonoBehaviour
{
    protected Animator _animator;
    protected readonly int _movingHash = Animator.StringToHash("isMoving");
    protected readonly int _deadHash = Animator.StringToHash("Dead");
    protected readonly int _deathHash = Animator.StringToHash("Death");
    protected readonly int _hideHash = Animator.StringToHash("isHiding");
    protected readonly int _hideTriggerHash = Animator.StringToHash("isHide");
    protected readonly int _groundHash = Animator.StringToHash("isGround");
    protected readonly int _airHash = Animator.StringToHash("isAir");
    protected readonly int _jumpHash = Animator.StringToHash("isJump"); 
    
    PlayerMovement _movement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = transform.parent.GetComponent<PlayerMovement>();
    }

    public void Moving(bool boolean)
    {
        _animator.SetBool(_movingHash, boolean);
    }

    public void Dead()
    {
        _animator.SetBool(_deadHash, true);
        _animator.SetTrigger(_deathHash);
    }

    public void Hiding(bool boolean)
    {
        _animator.SetBool(_hideHash,boolean);
        if(boolean)
            _movement.gameObject.layer = 7;
        else
            _movement.gameObject.layer = 6;
    }

    public void DoHide()
    {
        _animator.SetTrigger(_hideTriggerHash);
    }

    public void IsGround(bool boolean)
    {
        _animator.SetBool(_groundHash, boolean);
        _animator.SetBool(_airHash, !boolean);
    }

    public void IsJumping()
    {
        _animator.SetBool(_jumpHash, true);
    }

    public void EndOfDeadAnim()
    {

    }


}
