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
    public Animator handgrab;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        m_prevFlex = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, m_controller);
        //print(m_prevFlex);
        handgrab.SetFloat("Flex", m_prevFlex);
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
                joint.breakForce = 20000;
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

    private void OnJointBreak(float breakForce)
    {
        grabobject = null;
        stillgrab = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("GameController")|| other.CompareTag("Key"))
        {
            grabobject = other.gameObject.GetComponent<Rigidbody>();
            if (!grabobject)
            {
                grabobject = other.gameObject.GetComponentInParent<Rigidbody>();
            }

        }
    }


}
