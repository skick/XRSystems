using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{

    public GameObject onHand;
    public GameObject collidingObject;

    public void Update()
    {
        if (Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger") > 0.2f && collidingObject)
        {
            GrabObject();
        }

        if (Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger") < 0.2f && onHand)
        {
            ReleaseObject();
        }
    }

    public void GrabObject()
    {
        onHand = collidingObject;
        onHand.transform.SetParent(this.transform);
        onHand.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void ReleaseObject()
    {
        onHand.GetComponent<Rigidbody>().isKinematic = false;
        onHand.transform.SetParent(null);
        onHand = null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GameObject>())
        {
            collidingObject = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        collidingObject = null;
    }
}
