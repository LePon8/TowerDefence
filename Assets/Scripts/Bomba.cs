using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BombMode
{
    Frag,
    Chain,
    Dot
}

public class Bomba : MonoBehaviour
{
    [SerializeField] private BombMode mode;
    [SerializeField] int damage;
    [SerializeField] float damageRadius;
    [SerializeField] LayerMask enemyMask;
    [SerializeField] GameObject BPrefab;




    private IEnumerator Detonate()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, damageRadius, enemyMask);
        


        foreach (var enemy in enemies)
        {
            Enemy temp = enemy.GetComponent<Enemy>();

            if (temp != null)
            {
                temp.TakeDamage(damage);
            }
        }

        yield return null;
        gameObject.SetActive(false);
        Debug.DrawRay(transform.position, Vector3.up * 10, Color.black, 5);
    }


    public IEnumerator Detonate(Vector3 position)
    {

        Collider[] enemies = Physics.OverlapSphere(position, damageRadius, enemyMask);
        GetComponent<Collider>().enabled = false;
        if (enemies.Length == 0) yield break;

        foreach (var enemy in enemies)
        {
            Enemy temp = enemy.GetComponent<Enemy>();

            if (temp != null)
            {
                temp.TakeDamage(damage);
                
            }
        }
        yield return new WaitForSeconds(1);

        foreach (var enemy in enemies)
        {
            Enemy temp = enemy.GetComponent<Enemy>();

            if (temp != null)
            {
                
                Detonate(transform.position);
                Debug.DrawRay(temp.transform.position, temp.transform.position + Vector3.up * 10, Color.black, 5);
            }
        }

        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Detonate(transform.position));
        Detonate();
    }
}
