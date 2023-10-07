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

       
        if (IsWalking() || IsRunning())
        {
            RotateCharacter();
        }
    }

    private void SetState(PlayerState newState)
    {
    
        foreach (PlayerState state in (PlayerState[])System.Enum.GetValues(typeof(PlayerState)))
        {
            _CharacterAnimator.SetBool(state.ToString(), false);
        }

       
        _CharacterAnimator.SetBool(newState.ToString(), true);

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

    private bool IsWalking()
    {
        return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
    }

    private bool IsRunning()
    {
        return Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D));
    }

    private bool Jumping()
    {
        return Input.GetKey(KeyCode.Space);
    }

    private bool Attacking()
    {
        return Input.GetKey(KeyCode.Mouse0);
    }

    private void RotateCharacter()
    {
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (inputDirection != Vector3.zero)
        {
         
            Quaternion targetRotation = Quaternion.LookRotation(inputDirection);

        
            _CharacterAnimator.transform.rotation = Quaternion.Slerp(_CharacterAnimator.transform.rotation, targetRotation, Time.deltaTime * 8f);
        }
    }
}
