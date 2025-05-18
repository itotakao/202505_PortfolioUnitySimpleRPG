using System.Collections;
using UnityEngine;

public class StateBase<T> where T : StateMachineBase<T>
{
    protected T machine;
    public StateBase(T _machine)
    {
        machine = _machine;
        machine.name = $"StateMachine:{GetType().Name}";
    }

    public virtual void OnEnterState() { }

    public virtual IEnumerator OnCoEnterState()
    {
        yield return null;
    }

    public virtual void OnUpdate() { }
    public virtual void OnExitState() { }
}