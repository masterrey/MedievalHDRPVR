using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHand : MonoBehaviour
{
    Rigidbody grabobject;
    FixedJoint joint;
    // Should be OVRInput.Controller.LTouch or OVRInput.Controller.RTouch.
    [SerializeField]
    protected OVRInput.Controller m_controller;
    private float m_prevFlex;
    public float grabBegin;
    bool stillgrab = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        m_prevFlex = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, m_controller);
        print(m_prevFlex);
        if (m_prevFlex >= grabBegin&& !stillgrab)
        {
            OnGrab();
        }
        if (m_prevFlex <= grabBegin && stillgrab)
        {
            OnDrop();
        }

    }

    void OnGrab()
    {
        if (grabobject)
        {
           
            if (!joint)
            {
                joint = gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = grabobject;
            }
        }
        stillgrab = true;
    }
    void OnDrop()
    {
        Destroy(joint);
        grabobject = null;
        stillgrab = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("GameController"))
        {
            grabobject = other.gameObject.GetComponent<Rigidbody>();


        }
    }


}
