using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] float shootRange = 30;
    [SerializeField] int gunDamage = 15;
    [SerializeField] LayerMask mask;
    [SerializeField] GameObject bomba;


    int myMask = 0;


    Transform pointShoot;

    // Start is called before the first frame update
    void Start()
    {
        pointShoot = transform.GetChild(0);

        int barrier = 3;
        int enemy = 5;

        myMask = ~((barrier) & (enemy));



        Debug.Log(Convert.ToString(myMask, 2).PadLeft(32, '0'));
    }

    private void Update()
    {
        SecondShoot();
    }


    public void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(pointShoot.position, pointShoot.forward, out hit, shootRange, mask))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(gunDamage); 
                
            }
        }

        Debug.DrawRay(pointShoot.position, pointShoot.forward * shootRange, Color.red, 3);
    }

    public void SecondShoot()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray2, out hit, 100))
            {
                Instantiate(bomba, new Vector3(hit.point.x, 10, hit.point.z), Quaternion.identity);
                //Enemy enemy = hit.transform.GetComponent<Enemy>();
                //if(enemy != null)
                //{
                //    enemy.TakeDamage(gunDamage);
                //}

            }

        }

       
    }

    //foreach


}
