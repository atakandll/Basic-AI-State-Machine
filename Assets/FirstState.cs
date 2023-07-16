using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff; // namespace kullandık.

public class FirstState : State<AI>
{
    private static FirstState instance;

    private FirstState()
    {
        if (instance != null)
        {
            return; //Eğer varsa, yapıcı metot geri döner ve birden çok örneğin oluşmasını engeller.
        }
        instance = this;
    }
    public static FirstState Instance //FirstState sınıfının yalnızca bir örneğinin olmasını sağlar
    {
        get
        {
            if (instance == null)
            {
                new FirstState();
            }
            return instance; //Instance ilk kez çağrıldığında örnek oluşturulur ve sonraki çağrılarda aynı örnek döndürülür.

        }
    }
    public override void EnterState(AI _owner)
    {
        Debug.Log("Entering first state");

    }

    public override void ExitState(AI _owner)
    {
        Debug.Log("Exiting first state");

    }

    public override void UpdateState(AI _owner)
    {
        if (_owner.switchState)
        {
            _owner.stateMachine.ChangeState(FirstState.Instance);
        }
    }
}
