using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHP = 100;
    [SerializeField] int moveSpeed = 5;
    [SerializeField] int damage = 5;

    private int currentHP;

    bool canMove = true;


    

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        
        if(currentHP <= 0)
        {

            gameObject.SetActive(false);
        }
    }


    //private void AttackBarrier(Barrier barrier)
    //{
    //    barrier.TakeDamage(damage);
    //    Destroy(gameObject);
    //}


    IEnumerator DelayedAttack(Barrier barrier)
    {
        canMove = false;       
        yield return new WaitForSeconds(2);
        barrier.TakeDamage(damage);
        Destroy(gameObject);

    }

    IEnumerator SecondCouroutin()
    {
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Barrier"))
        {
            Barrier barrier = collision.transform.GetComponent<Barrier>();

            StartCoroutine(DelayedAttack(barrier));
        }
    }

    
}
