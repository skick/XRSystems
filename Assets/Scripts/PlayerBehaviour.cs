using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public void ChangeScale(float multiplyer)
    {
        transform.localScale = new Vector3(multiplyer, multiplyer, multiplyer);
    }
}
