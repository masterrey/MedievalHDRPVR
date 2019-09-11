using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrab : MonoBehaviour
{
  
    Rigidbody thing;
    FixedJoint joint;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (thing != null && Input.GetButtonDown("Fire1") && thing.CompareTag("Grab"))
        {
            if (joint == null)
            {
                joint= thing.gameObject.AddComponent<FixedJoint>();
                joint.breakForce = 200;
                joint.connectedBody = GetComponent<Rigidbody>(); ;
            }
        }
        if (thing != null && Input.GetButtonUp("Fire1") && thing.CompareTag("Grab"))
        {
            Destroy(joint);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grab"))
        {
            Rigidbody rdb = other.gameObject.GetComponent<Rigidbody>();
            if (rdb)
            {
                thing = rdb;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (thing!=null && other == thing.gameObject)
        {
            Destroy(joint);
            thing = null;
        }
    }
}
