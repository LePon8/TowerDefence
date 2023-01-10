using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    Gun gun;


    //Vector3 oldPosition;
    Vector3 newPosition;
    //float movementProgress;


    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        gun = GetComponentInChildren<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//0 left click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Debug.DrawRay(ray.origin, ray.direction, Color.red, 10);

            RaycastHit hit;
            if( Physics.Raycast(ray, out hit, 100))
            {
                //oldPosition = transform.position;
                newPosition = new Vector3(hit.point.x, transform.position.y, transform.position.z);
                //movementProgress = 0;

                //Debug.DrawRay(newPosition, Vector3.up * 10, Color.black, 5);

                
            }
        }

        
        
           transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);


        //Debug.Log(gameObject.transform.position);

        if (Input.GetButtonDown("Jump"))
        {
            if (gun)
            {
                gun.Shoot();

            }

        }
        
        
    }
}
