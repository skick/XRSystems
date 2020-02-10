using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallDistanceText : MonoBehaviour
{
    public GameObject ball;
    public Text distanceText;

    void Update()
    {
        distanceText.text = ball.GetComponent<Transform>().position.y.ToString("0.0m");
    }
}
