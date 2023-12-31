using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateStuff
{
    public class StateMachine<T>
    {

        public State<T> currentState { get; private set; }
        public T Owner; // "T", genel bir tür parametresini temsil eder,kullanıcıya özel veri tipini belirleme olanağı sağlar.

        public StateMachine(T _o)
        {
            Owner = _o;
            currentState = null;
        }
        public void ChangeState(State<T> _newState)
        {
            if (currentState != null)
                currentState.ExitState(Owner);

            currentState = _newState;
            currentState.EnterState(Owner);
        }
        public void Update()
        {
            if (currentState != null)
                currentState.UpdateState(Owner);
        }

    }
    public abstract class State<T>
    {
        public abstract void EnterState(T _owner);
        public abstract void ExitState(T _owner);
        public abstract void UpdateState(T _owner);
    }

}
