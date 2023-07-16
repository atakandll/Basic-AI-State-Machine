using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff; // namespace kullandık.

public class SecondState : State<AI>
{
    private static SecondState instance;

    private SecondState()
    {
        if (instance != null)
        {
            return; //Eğer varsa, yapıcı metot geri döner ve birden çok örneğin oluşmasını engeller.
        }
        instance = this;
    }
    public static SecondState Instance //FirstState sınıfının yalnızca bir örneğinin olmasını sağlar
    {
        get
        {
            if (instance == null)
            {
                new SecondState();
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
        if (!_owner.switchState)
        {
            _owner.stateMachine.ChangeState(FirstState.Instance);
        }
    }
}
