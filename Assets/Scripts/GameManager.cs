using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    
    //public delegate void MyDelegate(int value); //delegate = contenitori per funzioni
    //public static event MyDelegate OnMyDelegate;
    //public MyDelegate myDelegate;

    //public static event Action OnGameOver;
    //public static event Action<int, bool> OnPlayerKill;

    //public UnityEvent myEvent;


    private void Start()
    {
        //myDelegate += GameStart;
        //myDelegate += GameOver;

        //myDelegate(32);
        //OnMyDelegate(50);
        //OnMyDelegate?.Invoke(12);
        //OnGameOver?.Invoke();

        //myEvent.Invoke();

        //int result = Fattoriale(4);
        

    }

    //private int Fattoriale(int number)
    //{
    //    if (number == 0)
    //        return 1;
    //    Debug.Log(number * Fattoriale(number - 1));

    //    return number * Fattoriale(number - 1);
    //}

    public void GameOver(int value)
    {
        Debug.Log("GameOver" + value);
    }

    void GameStart(int value)
    {
        Debug.Log("StartGAme" + value);
    }
}
