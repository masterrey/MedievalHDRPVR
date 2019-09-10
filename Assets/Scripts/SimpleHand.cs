using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHand : MonoBehaviour
{
    RaycastHit hit;
    int forcedirection = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            forcedirection = -forcedirection;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out hit, 100)){

            Debug.DrawLine(transform.position, hit.point);
            if (Input.GetButtonDown("Fire1"))
            {
                Rigidbody rdb = hit.collider.gameObject.GetComponent<Rigidbody>();
                if (rdb)
                {
                    rdb.AddForceAtPosition(transform.forward* forcedirection, hit.point, ForceMode.Impulse);
                }
            }

        }
    }
}
