using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Barrier : MonoBehaviour
{
    [SerializeField] int maxHP;
    [SerializeField] Image HPBar;
    int currentHP;
    public UnityEvent myEvent;

    private void Awake()//Chiamato prima dello start
    {
        //GameManager.OnMyDelegate += TakeDamage;
        currentHP = maxHP;
    }


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        UpdateHPBar();
        
        if (currentHP <= 0)
        {
            Destroy(gameObject);
            myEvent.Invoke();
        }
    }





    void UpdateHPBar()
    {
        HPBar.fillAmount = (float)currentHP / maxHP;
    }
}
