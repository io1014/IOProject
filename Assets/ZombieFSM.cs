using System;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFSM : GameObjectFSM
{
    Dictionary<ZombieState, GameObjectFSMState> _state = new Dictionary<ZombieState, GameObjectFSMState>();
    Action _callback;

    void Awake()
    {
        _state.Add(ZombieState.Idle, new ZombieIdleState(gameObject));
        _state.Add(ZombieState.Patroll, new ZombiePatrollState(gameObject));
        _state.Add(ZombieState.AttackMove, new ZombieAttackMoveState(gameObject));
        _state.Add(ZombieState.Die, new ZombieDieState(gameObject));
        _state.Add(ZombieState.Attack, new ZombieAttAckState(gameObject));
    }

    public void ChangeStateByEnum(ZombieState type)
    {
        _callback = null;
        ChangeState(_state[type]);
    }
    void AnimCallback()
    {
        _callback?.Invoke();
    }
    public void SetAnimStateCallback(Action action)
    {
        _callback = action;
    }
}

public enum ZombieState
{
    Idle,
    Patroll,
    AttackMove,
    Attack,
    Die,
}
