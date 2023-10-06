using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private enum PlayerState
    {
        Idle,
        IdleBreaker,
        Walk,
        Run,
        Jump,
        Attack
    }
    private bool IsWalking()
    {
        return Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift);
    }
    private bool IsRunning()
    {
        return Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift);
    }
    private bool Jumping()
    {
        return Input.GetKey(KeyCode.Space);
    }
    private bool Attacking()
    {
        return Input.GetKey(KeyCode.Mouse0);
    }
    private bool Breaking()
    {
        return Input.GetKey(KeyCode.E);
    }
    public Animator _CharacterAnimator;
    private PlayerState _currentState;
    void Start()
    {
        SetState(PlayerState.Idle);
    }
    void Update()
    {
        PlayerState newState = DeterminateState();
        if (newState != _currentState)
        {
            SetState(newState);
        }
    }
    private void SetState(PlayerState newState)
    {
        switch (_currentState)
        {
            case PlayerState.Idle:
                _CharacterAnimator.SetBool("Idle", false); break;
            case PlayerState.IdleBreaker:
                _CharacterAnimator.SetBool("IdleBreaker", false); break;
            case PlayerState.Walk:
                _CharacterAnimator.SetBool("Walk", false); break;
            case PlayerState.Run:
                _CharacterAnimator.SetBool("Run", false); break;
            case PlayerState.Jump:
                _CharacterAnimator.SetBool("Jump", false); break;
            case PlayerState.Attack:
                _CharacterAnimator.SetBool("Attack", false); break;
        }
        switch (newState)
        {
            case PlayerState.Idle:
                _CharacterAnimator.SetBool("Idle", true); break;
            case PlayerState.IdleBreaker:
                _CharacterAnimator.SetBool("IdleBreaker", true); break;
            case PlayerState.Walk:
                _CharacterAnimator.SetBool("Walk", true); break;
            case PlayerState.Run:
                _CharacterAnimator.SetBool("Run", true); break;
            case PlayerState.Jump:
                _CharacterAnimator.SetBool("Jump", true); break;
            case PlayerState.Attack:
                _CharacterAnimator.SetBool("Attack", true); break;
        }
        _currentState = newState;
    }
    private PlayerState DeterminateState()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            return PlayerState.IdleBreaker;
        }
        else if (IsRunning())
        {
            return PlayerState.Run;
        }
        else if (IsWalking())
        {
            return PlayerState.Walk;
        }
        else if (Jumping())
        {
            return PlayerState.Jump;
        }
        else if (Attacking())
        {
            return PlayerState.Attack;
        }
        else
        {
            return PlayerState.Idle;
        }
    }
}