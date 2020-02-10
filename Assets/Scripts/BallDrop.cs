using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDrop : MonoBehaviour
{

    public float droppingDistance;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position; 
    }

    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.Four))
        {
            DropBall();
        }
    }

    private void DropBall()
    {
        transform.position = new Vector3(startPos.x, droppingDistance, startPos.z);
    }


}
