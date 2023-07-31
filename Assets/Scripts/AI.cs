using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class AI : MonoBehaviour
{
    public bool switchState = false;
    public float gameTimer;
    public int seconds = 0; //Oyunun başladığından bu yana geçen saniyelerin sayısını takip eden 

    public StateMachine<AI> stateMachine { get; private set; }

    private void Start()
    {
        stateMachine = new StateMachine<AI>(this);
        stateMachine.ChangeState(FirstState.Instance); //bu da AI'nin ilk durumunu temsil eden bir sınıf olduğunu gösterir.
        gameTimer = Time.time; //Bu, oyun başladığından beri geçen süreyi takip etmek için yapılır.



    }
    private void Update()
    {
        if (Time.time > gameTimer + 1) //blok içindeki kodun saniyede bir kez çalıştırılmasını sağlar.
        {
            gameTimer = Time.time; //yeni bir saniyenin başlangıcını işaretler.
            seconds++;
            Debug.Log(seconds);


            if (seconds == 5)
            {
                seconds = 0;
                switchState = !switchState;

            }
            stateMachine.Update();

        }

    }
}
